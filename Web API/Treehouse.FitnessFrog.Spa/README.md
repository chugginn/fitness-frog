
# Fitness Frog API

## Supported User Actions

* Viewing a list of entries
* Adding an entry
* Editing an entry
* Deleting an entry


## Endpoints

* /api/entries GET, POST
* /api/entries/1 GET, PUT, DELETE
* /api/activities GET
* /api/intensities GET

## HTTP Status Codes

* 200 OK
* 201 Created
* 204 No Content
* 400 Bad Request
* 500 Internal Server Error


# Exercise: Adding the Activities and Intensities API Endpoints

## Activities API Endpoint

* Add an API controller named `ActivitiesController`
* Add a controller action method to handle GET requests
  * The method should return a collection of resources representing the available activities
* Each returned activity resource should have an `id` and `name` property
* Use the `ActivitiesRepository.GetList` method to get a list of the available activities

## Intensities API Endpoint

* Add an API controller named `IntensitiesController`
* Add a controller action method to handle GET requests
  * The method should return a collection of resources representing the available intensities
* Each returned intensity resource should have an `id` and `name` property
* Use the .NET Framework `Enum.GetValues` static method to enumerate the values of the `Entry.IntensityLevel` enumeration