#  Beginner SOLID Test – Smart Home Refactoring

##  Original Problem

The original `SmartHomeManager` class was:

- Responsible for **too many things** (device control, alerts, DB saving, external API calls)
- Contained **hardcoded dependencies** like `new SqlDatabase()` and `new EmailSender()`
- Difficult to **extend** (e.g., adding a new alert type or external service)
- Not suitable for **unit testing** due to lack of dependency injection

---

##  Refactoring Goals

- Improve **modularity**, **flexibility**, and **testability**
- Keep the **external behavior unchanged**
- Make the system **easier to extend and maintain**

---

##  What Was Changed (with Reasoning)

| Change | Why |
|-------|-----|
|  Extracted interfaces (`IDatabase`, `IAlertService`, `IExternalNotifier`) | To allow flexible and swappable components |
|  Moved logic out of `SmartHomeManager` | To keep each class focused on a single task |
|  Replaced conditionals inside `SendAlert` with polymorphism | To reduce clutter and support future alert types |
|  Used constructor injection for all services | To allow for mocking and easier testing |
|  Created real and mock implementations for each service | To support both real usage and test scenarios |

---

##  After Refactoring – New Architecture

SmartHomeManager
├── IDatabase
│   └── SqlDatabase
├── IAlertService
│   └── AlertService
│       ├── EmailSender
│       └── SmsSender
└── IExternalNotifier
    └── GoogleNotifier
        └── GoogleHomeApi