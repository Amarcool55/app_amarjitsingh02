pipeline {
  agent any

  tools {
    dockerTool 'Docker'
  }

  environment {
    scannerHome = tool name:'sonar_scanner_dotnet'
    username = 'amarjitsingh02'
  }

  stages {
    stage('start') {
      steps {
        git branch: 'master', changelog: false, poll: false, url: 'https://github.com/Amarcool55/app_amarjitsingh02.git'
      }
    }

    stage('Nuget Restore') {
      steps {
        bat "dotnet restore"
      }
    }

    stage('Start sonarqube analysis') {
      steps {
        echo "Starting Sonar analysis"
        withSonarQubeEnv('Test_Sonar') {
          bat "dotnet ${scannerHome}\\SonarScanner.MSBuild.dll begin /k:\"sonar-${username}\" /d:sonar.verbose=true -d:sonar.cs.xunit.reportsPath='test-project/TestResults/TestResult.xml'"
        }
      }
    }

    stage('Code Build') {
      steps {
        bat "dotnet clean"
        bat "dotnet build"
      }
    }

    stage('Test case execution') {
      steps {
        bat 'dotnet test test-project\\test-project.csproj -l:trx;LogFileName=TestResult.xml'
      }
    }

    stage('Stop sonarqube analysis') {
      steps {
        echo "stop sonar"
        withSonarQubeEnv('Test_Sonar') {
          bat "dotnet ${scannerHome}\\SonarScanner.MSBuild.dll end"
        }
      }
    }

    stage('Kubernetes Deployment') {
      steps {
        echo "Release artifacts"
        bat "dotnet publish -c Release -o publish/"

        echo "Create docker image"
        bat "docker build -t amarcool55/i-${username}-${BRANCH_NAME}:latest ."

        echo "Publish docker image"
        script {
			withDockerRegistry(credentialsId:'4774f646-4917-469c-8299-2f5cf5d94652', toolName: 'docker') {
				bat "docker push amarcool55/i-${username}-${BRANCH_NAME}:latest"
			}
		}

        echo "Run Kubernetes Deployment"
        bat "kubectl apply -f deployment.yaml"
      }
    }
    
  }
}