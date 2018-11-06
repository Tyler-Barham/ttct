# TTCT
TTCT is Tyler's Text Comparison Tool. It's used to find all the unique words that appear in the input file/folder but do not appear in the comparison file/folder.

## Getting Started
These instructions will get you a copy of the project up and running on your local machine for development and testing purposes.

### Prerequisites
```
.NET Core 2.1
```

### Installing
```
$ pwd
/

$ git clone https://github.com/Tyler-Barham/TTCT.git
$ cd /TTCT/TTCT
$ dotnet build
```

### Example Usage
```
$ pwd
/TTCT/TTCT/bin/Debug/netcoreapp2.1

$ dotnet TTCT.dll --help
$ dotnet TTCT.dll if=~/Downloads cf=../../myFolder
$ dotnet TTCT.dll if=./myFolder cf=./myFolder/subFolder --use-stemmer
```

### Testing
Unit tests are written in MSTest.

```
$ pwd
/TTCT/TTCTUnitTest

$ dotnet build
$ dotnet test
```

___
