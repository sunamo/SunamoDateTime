# SunamoDateTime

## Short description

Rozsáhlá knihovna pro práci s datem a časem v .NET.


Working with date+time

## Overview

SunamoDateTime is part of the Sunamo package ecosystem, providing modular, platform-independent utilities for .NET development.

## Main Components

### Key Classes

- **ConvertDateTimeToFileNamePostfix**
- **ConvertDateTimeToFileNamePrefix**
- **UnixDateConverter**
- **DTOnlyNumber**
- **DateTimeOrShort**
- **FromToTDateTime**
- **DTHelper**
- **DTHelperCode**
- **DTHelperCs**
- **DTHelperEn**

### Key Methods

- `ToConvention()`
- `To()`
- `From()`
- `Sh()`
- `Dt()`
- `IsValidTimeText()`
- `IsValidDateTimeText()`
- `IsValidDateText()`
- `ParseDateUSA()`
- `StringToDateTimeFormalizeDate()`

## Installation

```bash
dotnet add package SunamoDateTime
```

## Dependencies

- **Microsoft.Extensions.Logging.Abstractions** (v9.0.3)

## Package Information

- **Package Name**: SunamoDateTime
- **Version**: 25.6.7.1
- **Target Framework**: net9.0
- **Category**: Platform-Independent NuGet Package
- **Source Files**: 38

## Related Packages

This package is part of the Sunamo package ecosystem. For more information about related packages, visit the main repository.

## License

See the repository root for license information.

<!-- sunamo:test-coverage:start -->
## Test coverage

| Metric | Value |
|---|---|
| Method | static |
| Test projects | 1 |
| Public types referenced by tests | 5/24 (20.8 %) |
| Public methods referenced by tests | 10/99 (10.1 %) |
| Line coverage | n/a |
| Branch coverage | n/a |
| Generated (UTC) | 2026-11-22 21:24 |

<!-- sunamo:test-coverage:data {"package":"SunamoDateTime","container":"pinp","testProjects":1,"publicTypes":24,"typesReferencedByTests":5,"publicMethods":99,"methodsReferencedByTests":10,"lineRate":null,"branchRate":null,"method":"static","generatedUtc":"2026-11-22 21:24"} -->
<!-- sunamo:test-coverage:end -->
