#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
COPY ./publish /app 
WORKDIR /app
EXPOSE 80
ENTRYPOINT ["dotnet", "nagp-devops-us.dll"]