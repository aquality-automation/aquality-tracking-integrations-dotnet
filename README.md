[![Quality Gate](https://sonarcloud.io/api/project_badges/measure?project=aquality-automation_aquality-tracking-integrations-dotnet&metric=alert_status)](https://sonarcloud.io/dashboard?id=aquality-automation_aquality-tracking-integrations-dotnet)
[![NuGet](https://img.shields.io/nuget/v/AqualityTracking.Integrations.Core)](https://www.nuget.org/packages/AqualityTracking.Integrations.Core)

# Aquality Tracking .NET Integrations 

The repository contains adaptors for .NET test frameworks.

## How to use

1. Add NuGet package according to the selected test framework (see below).
2. Add [aqualityTracking.json](./AqualityTracking.Integrations/src/AqualityTracking.Integrations.Core/Resources/aqualityTracking.Template.json) with corresponding values to the `Resources` folder. Set `Build Action: None` and `Copy to Output Directory: Copy always`.

You are able to override these values from CI build via environment variables:

```bash
    aquality.enabled={true/false} 
    aquality.host={aquality_tracking_address}
    aquality.token={api_token}
    aquality.projectId={project_id}
    aquality.executor={name_of_executor}
    aquality.suiteName={test_suite_name} 
    aquality.buildName={build_name} 
    aquality.environment={execution_env} 
    aquality.ciBuild={link_to_ci_build} 
    aquality.debug={true/false}
```

## SpecFlow 3.x [![NuGet](https://img.shields.io/nuget/v/AqualityTracking.SpecFlowPlugin)](https://www.nuget.org/packages/AqualityTracking.SpecFlowPlugin)

To use this adaptor with SpecFlow you have to add `AqualityTracking.SpecFlowPlugin` NuGet package.

Also add the following `stepDefinition` assembly to [specflow.json](https://specflow.org/documentation/configuration/).

```json
"stepAssemblies": [
    { "assembly": "AqualityTracking.SpecFlowPlugin" }
]
```

### License

Library's source code is made available under the [Apache 2.0 license](https://github.com/aquality-automation/aquality-tracking-integrations-dotnet/blob/master/LICENSE).
