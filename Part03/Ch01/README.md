- workflows/ci-cd.yaml
```yaml
name: Continous Integration and Deployment

on:
  push:
    branches:
      - main

jobs:
  build:
    runs-on: ubuntu-latest
    steps:
      - name: Check out code
        uses: actions/checkout@v2

      - name: Run a one-line script
        run: echo Hello, world!

      - name: Setup .NET 5
        uses: actions/setup-dotnet@v1
        with:
          dotnet-version: '5.0.x'

      - name: Restore dependencies
        run: dotnet restore

      - name: Build app
        run: dotnet build -c Release --no-restore

      - name: Run automated tests
        run: dotnet test -c Release --no-build
```