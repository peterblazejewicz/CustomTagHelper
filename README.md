# CustomTagHelper
An ASP5 MVC6 custom tag helper sample project using Material Design Lite

## Description

For bash like terminals it can be useful to use `Nodemon` to restart `dnx` after .NET files are changed - as at the time of writing `beta5` dnx does not work with `--watch` option on *nix clients.

Workaround:
```bash
#nodemon for dnx
DNX_DEFAULT_DIR=.
DNXMON_CMD=kestrel
dnxmon () {
  nodemon -e cs,json,cshtml -x "dnx ${1-$DNX_DEFAULT_DIR} ${DNXMON_CMD}"
}
```
Usage:
```
dnxmon . kestrel
```

## How to create tag helper?

```bash
mkdir TagHelpers
cd TagHelpers
yo aspnet:TagHelper MenuLinkTagHelper
You called the aspnet subgenerator with the arg MenuLinkTagHelper
MenuLinkTagHelper.cs created.
   create MenuLinkTagHelper.cs
```

Original source:
http://techiejourney.com/custom-taghelper-to-highlight-current-selected-menu-in-mvc-6/