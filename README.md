# TDDByExample

A professional **Test-Driven Development (TDD)** portfolio project built with .NET 8, following the complete **Red → Green → Refactor** workflow to demonstrate backend development skills.

## Project Goal

This project is designed to provide a comprehensive introduction to TDD while showcasing its practical application. The ultimate goal is to build a simple banking transaction management system while adhering to **Clean Code** principles, a layered architecture, and high test coverage.

This project is well-suited for showcasing on **LinkedIn** and **GitHub** to attract backend .NET career opportunities.

## Technologies Used

- **Framework:** .NET 8
- **Testing:** xUnit, FluentAssertions, Moq
- **Architecture:** Lightweight Clean Architecture
- **Tools:** Visual Studio 2022/2024

## Project Structure

- **TDDByExample.Domain** → Contains Entities, Interfaces, Services, and Business Logic
- **TDDByExample.Api** → Presentation Layer (Web API)
- **TDDByExample.Tests** → Unit and Integration Tests

## Project Progress (Daily)

### Day 1: Introduction to TDD and Initial Project & Test Environment Setup

**Completed Tasks:**

- Created a solution named **TDDByExample**
- Created the following projects:
  - `TDDByExample.Domain` (Class Library)
  - `TDDByExample.Api` (ASP.NET Core Web API)
  - `TDDByExample.Tests` (xUnit Test Project)
- Installed the required NuGet packages:
  - xUnit and xunit.runner.visualstudio
  - FluentAssertions
  - Moq
  - Microsoft.NET.Test.Sdk
  - Microsoft.AspNetCore.Mvc.Testing (for future API testing)
- Created the initial folder structure:
  - Entities, Interfaces, Services, Exceptions (within the Domain project)
  - UnitTests, IntegrationTests (within the Tests project)
- Wrote and executed the first simple test to verify the setup
- Created the initial README.md file
- Prepared the solution for successful compilation and test execution

### Day 2: Red-Green-Refactor Cycle + First TDD Implementation

**Completed Tasks:**

- Implemented `TransactionValidator` following the complete TDD workflow
- Wrote multiple unit tests using both `Fact` and `Theory`
- Used FluentAssertions for more readable and expressive assertions
- Created the base `Transaction` entity
- Gained practical experience with the Red → Green → Refactor cycle
- Added test coverage for positive, negative, and zero-value scenarios

**Test Coverage Status:** 100% coverage for `TransactionValidator`

### Day 3: Testing Conditional Logic, Exceptions, and Edge Cases

**Completed Tasks:**

- Extended `TransactionValidator` with real-world constraints
- Implemented boundary testing (upper and lower limits)
- Added exception-based tests using `Should().Throw<>`
- Used `[Theory]` and `[InlineData]` to validate multiple input scenarios
- Improved the `Transaction` entity with initial validation rules
- Achieved strong test coverage for both valid and invalid scenarios

**Test Coverage Status:** Very high coverage for transaction validation logic

### Day 4: FIRST Principles + Test Naming Conventions

**Completed Tasks:**

- Introduced and applied the FIRST principles for writing professional tests
- Fully refactored `TransactionValidatorTests`
- Implemented standard Naming Convention (Given-Should pattern)
- Used constructor-based test setup to reduce code duplication
- Improved readability, maintainability, and execution clarity of tests
- Ensured full adherence to Self-Validating and Independent test principles

**Current Test Status:** High-quality, readable, and production-grade test suite

### Day 6: Repository Pattern with TDD (Interface + InMemory Repository)

**Completed Tasks:**

- Fully implemented `ITransactionRepository`
- Created `InMemoryTransactionRepository` for unit testing purposes
- Wrote repository tests using a TDD approach
- Added core methods (Add, GetAll, GetById, Clear)
- Improved testability of the data access layer
- Fully decoupled the Domain layer from storage implementation details

**Status:** Repository layer is ready for use in services

### Day 7: Service Layer Pattern with TDD (Business Logic + Validation)

**Completed Tasks:**

- Extended the entity model with `TransactionType` (Deposit/Withdrawal)
- Enhanced business rules within the Validator and Service layers
- Implemented `AddTransaction`, `GetBalance`, and `GetAllTransactions` methods
- Wrote comprehensive business logic tests using mocking techniques
- Added exception handling for business rule violations
- Strengthened the Service layer as the core of the application's business logic

**Status:** Service layer is ready for integration with the API layer