# Hahn.ApplicationProcess.Application
Hahn Application process project

## To run this application with docker compose

    1. navigate to project root folder(solution root)
    2. Open a command prompt, git bash in the directory
    3. run `docker compose up -d`
    4. then wait for the build process to complete

## Project Folder structure
    1. 'backend' folder contains the aspnet core project and class libraries
    2. 'frontend' folder contains the aurelia front end project.
    3. The solution root also contains a docker 
    compose file used to run each 'Dockerfile' in both the front and back end

## When you make changes in the code
    1. run `docker compose down`// to bring down the images
    2. run `docker compose build`// to rebuild
    3. run 'docker compose up -d` //to run the app again
