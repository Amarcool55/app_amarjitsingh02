#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 
COPY ./publish /app 
WORKDIR /app
EXPOSE 80
ENTRYPOINT ["dotnet", "nagp-devops-us.dll"]