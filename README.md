# RobotApocalypse

This is a REST API built using .NET 6 that stores information about survivors and the resources they own. This is a bare minimum fulfilment of the specifications of the project.

## Setup

### Database Setup
In the project root path, execute the following command:
`dotnet ef database update`

The database is a Sqlite database named Apocalypse.db which will be added to the project root.

## Use Cases

### Add Survivors to the Database

Make a POST request to `api/Survivors`. The payload for the request is a json object with the following structure:
```
{
  "name": "string",
  "age": 0,
  "gender": "string",
  "lastLocationLatitude": 0,
  "lastLocationLongitude": 0,
  "resources": [
    0
  ]
}
```

### Update Survivor Location

In order to update the survivor's current location make a PUT request to `api/Survivors/updateSurvivorLocation`. The payload is as follows:
```
{
  "survivorId": 7,
  "newLatitude": 0,
  "newLongitude": 0
}
```
`survivorId` has to match the Survivor's Id

### Flag Survivor as Infected

Make a PUT call to `api/Survivors/flagSurvivorAsInfected` with the payload:
```
{
  "reporterId": 0,
  "infectedSurvivorId": 0
}
```
Both reporterId and infectedSurvivorId have to be valid Id of Survivors

###Connect to the Robot CPU system

To get a full list of robots from the server call the GET endpoint `api/Robots`
To filter robots by he Category (Flying/Land) use `api/Robots/{category}` GET endpoint.
`category` is a number representing the categories:
``0`` - All. Returns all robots from the server without applying a filter. Same results as the `api/Robots` endpoint
``1`` - Land. Filters the robots to only return the ones with the Land category
``2`` - Flying. Filters the robots to only return the ones with the Flying category
