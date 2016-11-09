# Unzipper
C# based Unzip utility

A WCF project which takes URL of a ZIP file and return a Dictionary of filename and byte array of files in it.

## Usage

```
Endpoint -> "http://localhost:31231/UnzipService.svc"
Request -> Name: "zipPath", value: "http://yourdomain.com/yourzipfile.zip", type: "System.String" 
```

I have published the WCF on Azure at http://unzipper.azurewebsites.net/


### Feel free to contribute to the utility.
