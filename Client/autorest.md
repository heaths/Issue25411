# Generated code configuration

Run `npx autorest autorest.md --csharp --shared-source-folder=<Azure.Core/src/Shared>` to generate code.

## AutoRest Configuration     
> see https://aka.ms/autorest 

``` yaml
# The title here is used to generate the single ClientOptions class name.
title: Jobs
license-header: MICROSOFT_MIT_NO_VERSION

input-file: ../Service/wwwroot/swagger.json
add-credentials: true
clear-output-folder: true
low-level-client: true

modelerfour:
  lenient-model-deduplication: true
```
