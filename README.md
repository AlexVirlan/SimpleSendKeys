![](https://raw.githubusercontent.com/AlexVirlan/SimpleSendKeys/main/Assets/SSK-screenshot.png)


# What is this?
Have you ever found yourself in a situation where you can't use the `copy-paste` functionality? Eg. some [RDP](https://en.wikipedia.org/wiki/Remote_Desktop_Protocol) connections (or apps) have it disabled. And it sucks!
SSK tries to solve this by allowing you to set a text payload (or it can sync to your keyboard - see the "recommended use" section below) and send each character as if you typed it.


# Recommended use
These are the recommended settings:
- Run on startup = on
- Minimize to tray = on
- Clipboard sync = on

This way, the app will run in the background at startup (accessible via the tray icon) and everything you have in the clipboard will be ready to be inserted just by using the hotkey. You can apply these settings by pressing the "Apply the recommended settings" button from the settings panel.


# Dependencies
- [.NET Desktop Runtime 8](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)
- [Newtonsoft.Json](https://www.newtonsoft.com/json) - no need to download this yourself, it will be included in the release.


# License
Free to use.


# Others
If you like this app, please support it by giving it a star on GitHub. Thanks!

# To do
- Implement 'Keep on top' option/setting.


<style>
h1 {
    margin-block-start: 1em;
}
</style>