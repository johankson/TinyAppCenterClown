# TinyAppCenterClown

An appcenter branch configuration tool that listens to github via githooks.

## What does it do?

It's a website/code thingy that you can connect to github via a githook that listens for new branches after a certain pattern. After a new branch is detected it configures it in AppCenter for you.

## Status

Conceptual - no code is written yet! :D

## Roadmap

1. iOS builds
2. The rest

## Detailed explanation

First you need to configure some base branches that will be the template for the configuration. These are known as Branch templates.



### Branch templates

Usually you have the **master** that will be the template for release builds and a **develop** that will be the for a development build.

These to branches are defined in TinyAppCenterClown as branch templates

| id | name | basedOnBranch  | certificatePassword | 
| ---|------| ---------------| --------------------| 
| develop-template        | Development template | develop|  ducksRus |
| release-template        | Release template | master | magicUnicorns |

### Routes

A route is a naming filter that you apply to the name of the incoming created branch and what branch template you want to match it to. If the filter match and there is no branch already configures in appcenter, it will configure it for you.

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
