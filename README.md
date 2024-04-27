![](https://raw.githubusercontent.com/AlexVirlan/SimpleSendKeys/main/Assets/SSK-screenshot.png)


# What is this?
Have you ever found yourself in a situation where you can't use the `copy-paste` functionality? Eg. some [RDP](https://en.wikipedia.org/wiki/Remote_Desktop_Protocol) connections (or apps) have it disabled. And it sucks!
SSK tries to solve this by allowing you to set a text payload (or it can sync to your keyboard - see the "recommended use" section below) and send each character as if you typed it.
<br><br>

# Recommended use
These are the recommended settings:
- Run on startup = on
- Minimize to tray = on
- Clipboard sync = on

This way, the app will run in the background at startup (accessible via the tray icon) and everything you have in the clipboard will be ready to be inserted just by using the hotkey. You can apply these settings by pressing the "Apply the recommended settings" button from the settings panel.
<br><br>

# Installation
Go to the [releases page](https://github.com/AlexVirlan/SimpleSendKeys/releases) and choose from the last version, one of the following options:
- Setup (recommended) - one executable file, the classic installation that we all know and love.
- Portable - one [7zip](https://www.7-zip.org/) file. Please be aware that if you are using a portable version and you enable the 'Run on startup' setting, you must not change the app's location/path. If you do change it, make sure that you open the app and disable then reenable the setting again.
<br><br>

# Dependencies
- [.NET Desktop Runtime 8.0.4](https://dotnet.microsoft.com/en-us/download/dotnet/8.0) - if you use the recommended setup version, you will be asked if you want to install it automatically (if you don't have it already installed).
- [Newtonsoft.Json](https://www.newtonsoft.com/json) - no need to download this yourself, it will be included in the release (both versions, setup and portable).
<br><br>

# License
Free to use.
<br><br>

# Others
If you like this app, please support it by giving it a star on GitHub. Thanks!
<br><br>

# To do
- Implement 'Keep on top' option/setting.
- Adding the possibility to send modifiers key.
