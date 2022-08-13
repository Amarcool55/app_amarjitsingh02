pipeline {
  agent any

  tools {
    dockerTool 'Docker'
  }

  environment {
    username = 'amarjitsingh02'
  }

  stages {
    stage('start') {
      steps {
        git branch: 'develop', changelog: false, poll: false, url: 'https://github.com/Amarcool55/app_amarjitsingh02.git'
      }
    }

    stage('Nuget Restore') {
      steps {
        bat "dotnet restore"
      }
    }

    stage('Code Build') {
      steps {
        bat "dotnet clean"
        bat "dotnet build"
      }
    }

    stage('Release artifact') {
    steps {
        bat "dotnet publish -c Release -o publish/"
    }
  }

    stage('Kubernetes Deployment') {
      steps {
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