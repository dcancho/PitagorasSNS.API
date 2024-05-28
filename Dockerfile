# Use the official Microsoft .NET Core runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0

# Set the working directory in the Docker container
WORKDIR /app

# Copy the published app to the working directory
COPY ./publish .

# Set the ASPNETCORE_ENVIRONMENT variable to Production
ENV ASPNETCORE_ENVIRONMENT=Production

# Expose port 80 for the app
EXPOSE 80

# Start the app
ENTRYPOINT ["dotnet", "PitagorasSNS.API.dll"]