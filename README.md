# AcornAPI

[![Build Status](https://dev.azure.com/blazewskileszek/Acorn/_apis/build/status/dex1g.AcornAPI?branchName=master)](https://dev.azure.com/blazewskileszek/Acorn/_build/latest?definitionId=4&branchName=master)

AcornAPI is a simple RESTful API that's designed to provide automation to the process of using **Acorn** bot, however the API can be easily implemented in any other botting application. It provides mechanisms for automated assigning of the accounts to the bots that have been set up (The decision that an account is finished or that a bot needs a new account assigned is made client-side).

It also provides an easy way to fetch data about the current state of the leveling process and create a management panel to see current progress, logs from all the machines and a way to remotely send some commands such as stopping/restarting the bot or rebooting the machine in case of some problems.

The minimal user input is one time configuration for each botting machine and making sure there are some new accounts in the database to refill the bots after they complete the process.

All endpoints all listed in Swagger with required JSON request bodies.

## Technologies used

- PostgreSQL 10.9
- .NET Core 2.2
- EntityFrameworkCore + LINQ
- AutoMapper
- Swagger
- JWT Authentication
- NUnit
- Azure Pipelines CI
