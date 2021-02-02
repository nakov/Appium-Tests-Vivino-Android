# Appium Tests Vivino Android

Appium-based automated tests for the "Vivino" app on Android. Implements the following test scenario:
1) Open the Vivino app in the Android emulator
2) Login with pre-регистеред email + password
3) Click on the [Search] tab
4) Find a wine by keywords: "Katarzyna Reserve Red 2006"
5) Open the first search result
6) Assert that the wine name is correct: "Reserve Red 2006"
7) Assert the rating is a number in the range [1.00 ... 5.00]
8) Assert the wine highlights contain "Among top 1% of all wines in the world"
9) Assert the wine facts hold "Grapes: Cabernet Sauvignon,Merlot"

## Vivino App Version
The automated tests are designed to test the **"Vivino" app for Android, version 8.18.11**, which can be downloaded as APK package from: https://www.apkmirror.com/apk/vivino/vivino-wine-scanner/vivino-wine-scanner-8-18-11-release/vivino-buy-the-right-wine-8-18-11-3-android-apk-download/download/

## Screenshots

![image](https://user-images.githubusercontent.com/1689586/106616260-0935d000-6576-11eb-9f02-c1b885e96bcb.png)

![image](https://user-images.githubusercontent.com/1689586/106616424-37b3ab00-6576-11eb-92ea-3524dd9264f0.png)

![image](https://user-images.githubusercontent.com/1689586/106616575-5e71e180-6576-11eb-8e20-c16e7aa8045a.png)

![image](https://user-images.githubusercontent.com/1689586/106616702-82cdbe00-6576-11eb-9a08-9b8159d60fc2.png)

![image](https://user-images.githubusercontent.com/1689586/106616844-ab55b800-6576-11eb-856c-684038b22c12.png)

![image](https://user-images.githubusercontent.com/1689586/106616979-d3ddb200-6576-11eb-9f60-2a9992625fcc.png)

