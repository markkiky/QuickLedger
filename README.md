# Introduction
This project mimicks a production Ruby on Rails application inspired by LedgerSync (https://www.ledgersync.dev/).
With the hope of creating a standard interface for accessing various ERP Finance modules.

# Future
There should be proper separation of data between onboarded clients and background jobs for long running task.

Addition of Grains through Orleans (https://dotnet.github.io/orleans/) to manage Entities would be a great addition. 
This would for example allow a customer grain to keep in sync with its counterpart in the ERP,
automatically updating any changes made to it locally and retrieving changes made in the ERP


