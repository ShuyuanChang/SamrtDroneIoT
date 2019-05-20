# SamrtDroneIoT
Smart Drone Remote Control with Azure IoT

#Publishing an app to run on the NVIDIA Jetson Nano:

    In the folder of TelloNetCore, run dotnet publish -r linux-arm64 for Linux running on Jetson Nano.

    Under ./bin/Debug/netcoreapp2.2/linux-arm64/publish you will see the whole self contained app that you need to copy to your Jetson Nano.


#Getting the app to run on the Nano.


    Install Linux on your Nano.

    Install the platform dependencies from your distro's package manager for .NET Core. .NET Core depends on some packages from the Linux package manager as prerequisites to running your application.

    Copy your app, i.e. whole publish directory mentioned above, to the Jetson Nano and execute run ./TelloNetCore to see OK! from .NET Core running on your Nano! (make sure you chmod 755 ./TelloNetCore)
