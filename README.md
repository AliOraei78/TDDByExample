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