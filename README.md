# Tabulator

The command line util to parse and convert tables between diferent formats. 

The unique feature is **prety print**. 

## Formats
### Input
* csv
* html
### Output formats
* csv
* html
* LaTeX
### In future release
* Markdown
* LaTeX (as input) 	
## Third party libs
* Command Line Parser Library: [www](http://commandline.codeplex.com/ "commandline.codeplex.com"), or [sources](https://github.com/gsscoder/commandline).
* Nunit : [www](http://www.nunit.org/ "nunit.org") for unit testing
## Usage
Classic unix usage:

```./tabulator.exe table.csv```

or

```./tabulator.exe -i csv -f LaTeX -o output.file.tex tab1.csv tab2.csv```

that means "inputn format csv, output format LaTex, output file output.file.tex and to process: tab1.csv, tab2csv"