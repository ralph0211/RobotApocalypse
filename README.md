# RobotApocalypse

This is a REST API built using .NET 6 that stores information about survivors and the resources they own.

## Setup



## Use Cases

### Add Survivors to the Database

A survivor must have a name, age, gender, ID, and last location (latitude, longitude). A survivor also has an inventory of resources (which you need to declare upon the registration of the survivor). This can include Water, Food, Medication, and Ammunition.

### Update Survivor Location

A survivor must have the ability to update their last location, storing the new latitude/longitude pair in the base (no need to track locations, just replacing the previous one is enough).

### Flag Survivor as Infected
