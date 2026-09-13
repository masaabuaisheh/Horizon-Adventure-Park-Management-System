# 🎢 Horizon Adventure Park Management System

A C# console application designed to manage the daily operations of **Horizon Adventure Park**.

The system provides a simple way for park staff to manage visitors, tickets, rides, reservations, and employees while enforcing important safety and operational rules.

## 📌 Overview

Horizon Adventure Park is replacing its paper-based visitor records and manual ride queues with a digital operations system.

This application simulates the core operations needed at ticket booths, ride entrances, and the park operations office.

The project was developed using **C#**, **.NET**, and **Object-Oriented Programming (OOP)** principles.

## ✨ Features

### 👤 Visitor Management

* Register new visitors
* Store visitor information and category
* Prevent duplicate visitor registrations

### 🎟️ Ticket Management

* Issue tickets to registered visitors
* Support different ticket types and access tiers
* Validate active tickets
* Deactivate or update ticket status
* Prevent the use of expired or cancelled tickets

### 🎢 Ride Management

* Add and manage rides
* Define ride safety requirements
* Track ride capacity and current occupancy
* Update ride status
* Support Open, Closed, and Under Maintenance states

### ✅ Ride Eligibility

Before allowing access to a ride, the system checks:

* Visitor age
* Visitor height
* Accompanying adult requirements
* Ticket validity
* Ticket access tier
* Ride operational status
* Ride capacity

If access is denied, the system provides a specific reason.

### 📅 Reservations

* Create ride reservations
* Cancel reservations
* Prevent duplicate reservations
* Prevent reservations when capacity is reached
* Prevent reservations for unavailable rides

### 👷 Staff Management

* Assign employees to rides or facilities
* Track employee availability
* Prevent conflicting employee assignments

### ⚠️ Error Handling

The system handles invalid operations with clear messages, including:

* Invalid user input
* Invalid or expired tickets
* Full rides
* Ineligible visitors
* Closed or unavailable rides
* Duplicate registrations or reservations
* Conflicting staff assignments
* Non-existing rides or visitors

## 🛠️ Technologies

* C#
* .NET
* Object-Oriented Programming (OOP)
* Visual Studio
* Console Application

## ▶️ How to Run

1. Clone the repository:

```bash
git clone https://github.com/YOUR-USERNAME/Horizon-Adventure-Park-Management-System.git
```

2. Open the project folder.

3. Open the `.sln` file using **Visual Studio**.

4. Build the solution.

5. Run the application.

Alternatively, if the .NET SDK is installed, run:

```bash
dotnet run
```

## 💡 Main Workflow

When the application starts, staff can select operations from the main menu, such as:

```text
=== Horizon Adventure Park — Operations System ===

1. Register Visitor
2. Issue Ticket
3. Validate Ride Access
4. Create Reservation
5. Manage Ride Status
6. Assign Staff
7. Exit
```

The application continues running until the user chooses to exit.

## 🧠 OOP Concepts

The project applies Object-Oriented Programming concepts to organize the different entities and responsibilities of the system, including visitors, tickets, rides, reservations, and employees.

## 📂 Project Purpose

This project demonstrates how C# and OOP can be used to model a real-world operational system while enforcing business rules, safety requirements, and consistent application state.

---
