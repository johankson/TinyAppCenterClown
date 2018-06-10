# TinyAppCenterClown

An appcenter branch configuration tool that listens to github via githooks.

## What does it do?

It's a website/code thingy that you can connect to github via a githook that listens for new branches after a certain pattern. After a new branch is detected it configures it in AppCenter for you.

## Features

* Multiple projects within a single installation


## Status

Conceptual - no code is written yet! :D

## Roadmap

1. iOS builds
2. The rest

## Detailed explanation

First you need to configure some base branches that will be the template for the configuration. These are known as Branch templates.

### Project

A project is a grouping of several routes. They are totally isolated from each other.




### Branch templates

Usually you have the **master** that will be the template for release builds and a **develop** that will be the for a development build.

These to branches are defined in TinyAppCenterClown as branch templates

| id | name | basedOnBranch  | certificatePassword | 
| ---|------| ---------------| --------------------| 
| develop-template        | Development template | develop|  ducksRus |
| release-template        | Release template | master | magicUnicorns |

### Build routes

A build route is a naming filter that you apply to the name of the incoming created branch and what branch template you want to match it to. If the filter match and there is no branch already configures in appcenter, it will configure it for you.

| id | name | filter  | branchTemplate | 
| ---|------| ---------------| --------------------| 
|    | feature-filter | feature/* | develop-template |
|    | releaseQA-filter  | releaseQA/* | develop-template |
|    | release-filter | release/* | release-template |

## Security issues

In order for the tool to work you need to submit/configure it with the certificate passwords.

## Other ideas

Random ideas.

### Automatic creation of builds and branches

Configure a route to automatically create a test and release branch for you. (avoid recursion here).

For example, if you check into a release/* branch then the TinyAppCenterClown will create a releaseQA/* branch with the development template beside the original template. However it will be a little bit messy what happens after the initial create. What happens if you push something to release/*, should the releaseQA also get the same commit automatically?


## TACC API

Draft of the public API (will be replaced by a swagger link later on)

### Configuration



### Projects

|Route|Method|Body|Description|
|----|----|---|---|
|```/projects```|GET|array of project-model|Gets all projects|
|```/projects/{id}```|GET|project-model|Get a specific project|
|```/projects```|POST|project-model|Creates a new project|
|```/projects/{id}```|DELETE||Creates a new project|
|```/projects/{id}```|PUT||Updates an existing project|

### Webhook

|Route|Method|Body|Description|
|----|----|---|---|
|```/projects/{id}/webhook```|POST|(github model)|Entrypoint of github webhook|

### Build templates

|Route|Method|Body|Description|
|----|----|---|---|
|```/projects/{project-id}/templates```|GET|array of template-model|Gets all build templates|
|```/projects/{project-id}/templates}/{id}```|GET|template-model|Get a specific build template|
|```/projects/{project-id}/templates```|POST|template-model|Creates a new project|
|```/projects/{project-id}/templates/{id}```|DELETE||Creates a new build template|
|```/projects/{project-id}/templates/{id}```|PUT||Updates an existing build template|

### Models

#### project-model

Describes one project

```json
{
    "id": 1,
    "name": "My fancy app",
    "appCenterToken": "213123"
}
```

#### template-model

Describes one build template

```json
{
    "id": 3,
    "name": "Develop template",
    "basedOnBranch": "develop",
    "certificatePassword": "InvalidDonkey"
}
```


#### route-model

Describes one build route

```json
{
    "id": 5,
    "name": "feature-filter",
    "branchTemplate": 3
}
```

## TACC Services

### IBuildSystemServiceFactory

Interface definition for building a IBuildSystemService for a specific project.

```csharp
public interface IBuildSystemServiceFactory
{
    IBuildSystemService Create(int projectId);
}
```

### IBuildSystemService

Interface definition for AppCenter (or a generic build system).

```csharp
public interface IBuildSystemService
{
    bool DoesBranchExist(string branch);
    bool IsBranchConfigured(string branch);
    void ConfigureBranch(BranchConfiguration configuration);
}
```

### IWebHookHandler

Definition of interface to handle incoming github requests

```csharp
public interface IWebHookHandler
{
    bool Handle(WebHookRequest request);
}
```