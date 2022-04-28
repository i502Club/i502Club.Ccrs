# i502Club.Ccrs
This is a .net project to support WA's CCRS cannabis reporting system for use 
within other .net applications.  The project simplifies creating the boilerplate 
code for common models, interfaces and enums which developers are likely to 
be working with when sending data to the Cannabis Central Reporting System(CCRS).

It is designed/organized so it can be used with the well known [CsvHelper](https://github.com/JoshClose/CsvHelper) library which enables 
efficient generation of the files expected by CCRS in WA State. You may find other creative 
usages for it as well.

This project is NON OFFICIAL and has not yet been validated for use in a production 
environment.  It is currently being developed and issues are expected to arise requiring 
fixes.

## Getting Started
To get started you must make a reference to the library from your project.

For most applications it will be the case that you will also want a NuGet 
package reference to CsvHelper.  CCRS is a csv file based system.

The models are intended to work well with CsvHelper to make the file generation process fast 
and easy.  It means the model properties are all in the right order so your CCRS files 
should generate properly by CsvHelper in terms of column placement.

There is great documentation for [CsvHelper](https://joshclose.github.io/CsvHelper/) if you need a quick primer on working with it.

The repository includes a test project that which has tests demonstrating the generation 
of an areas CCRS file.  The tests show the steps one can use to create and then read 
from a CCRS file using CsvHelper. It also includes some helper funcs and 
custom converters can be useful for jump starting an app.

### About the Install
You are free to download the compiled library or clone the repository and compile it 
if you prefer.  There is a compiled net standard 2 version available for download. 

### Development
This project may see breaking changes.  Please implement accordingly.


---

*Congratulations*! The library is ready to go and you should proceed with creating 
something cool for WA canna.  This files generated by this code base have not yet 
been validated and all information pertaining to CCRS must come directly from the WSLCB 
or their [online resources](https://lcb.wa.gov/ccrs/resources).

![CCRS](i502Club.Ccrs/images/ccrs_logo.png)

---

### Dependencies

 * net frameworks (i502Club.Ccrs)
 * CsvHelper (i502Club.Ccrs.Tests)

## History
This project is used by i502 Club systems for generating in house test CCRS files 
but it has NOT been vetted against the actual CCRS system. When validation 
testing proceeds remaining issues that require attention will get addressed.

## Authors
[![i502 Club](i502Club.Ccrs/images/logo.png)](https://www.i502.club) [i502 Club](https://www.i502.club)

This project was built using [documentation](https://lcb.wa.gov/ccrs/resources) provided for the general community by WSLCB.

## License
This project is licensed under the MIT License - see the [LICENSE.txt](LICENSE.txt) file for details

## Acknowledgments
* All the contributors to i502

## Contribute
You can create an issue or submit a pull request to help make the project better.
