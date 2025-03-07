# Chain Of Responsibility Kata (CORK)

A starting point for the CORK - Chain of Responsibility Kata.

## Background

Many ASP.NET applications tend to have a lot of duplicate cross-cutting concern code in every endpoint, action, or "business" method. In most cases, the cross-cutting concerns of validation, error handling, and more can be refactored into fewer less repetitive modules using patterns like decorator or even better, Chain of Responsibility. This kata is designed to teach developers how to refactor legacy code into a better design by practicing applying the Chain of Responsibility pattern to a couple of simple API endpoints.

MediatR and similar libraries can be used to standardize the interface of commands and queries in systems so that instead of having to create separate custom decorators for every business service class, a small set of *behaviors* (aka middleware) can be used and applied to nearly every request or operation. In order to refactor to use MediatR you typically need to replace the use of business services (or business logic in your UI layer) with a command (IRequest) and an associated handler (IRequestHandler). The business logic that was previously in the service simply gets moved into the handler, and then in a later refactoring it can be replaced with middleware.

## Instructions

1. Review the application and its two main endpoints for GetById and Create in the XXXController and associated XXXManager classes.
2. Look for cross-cutting concerns like validation and error handling.
3. Pick one of the endpoints. Modify it to use a command (AddHeroCommand is included in the starting code) by injecting MediatR and sending the command.
4. Implement the handler for the command. Initially it can just take all the logic from the Manager class method and do the same thing.
5. Make sure all tests still pass.

