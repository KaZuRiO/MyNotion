# Backend - Clean Architechture

## Domain

* Define Entities
* Define EntitiesRepository (Interface)
* Name the function

  |

  V

## Application

Define UseCase (InternalLogic) || Define Services (ExternalLogic)

* Link UseCase to Interface
* Can add business logic UseCase
* (CQRS) (Optimize database with sql)

  |

  V

## API

Use to define controllers

* Implement try catch

    |

    V

## Infrastrucutre

Call database context and link it with function

* Repository

  * Define context
  * Call method
* Define context
* Link context to the application
