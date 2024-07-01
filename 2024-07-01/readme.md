# Age Calculator

This is a Python application that calculates a user's age based on their date of birth (DOB) and allows the user to save the output in a CSV, PDF, or TXT file format.

## Features

- Prompts the user to enter their date of birth (DOB) in the format "YYYY-MM-DD".
- Calculates the user's age based on their DOB and the current date.
- Allows the user to select a file type (CSV, PDF, or TXT) to save the output.
- Saves the DOB and age to the selected file type.
- Provides an option to enter another input or generate the output.

## Prerequisites

- Python 3.x installed on your system.
- `reportlab` library installed (if you want to save output in PDF format).

## Installation

1. Clone the repository or download the source code.
2. Create a virtual environment for the project:

```bash
python -m venv venv
```

3. Activate the virtual environment:

On Windows:
```bash
venv\Scripts\activate
```

On Unix or MacOS:
```bash
source venv/bin/activate
```

4. Install the required packages using the following command:

```bash
pip install -r requirements.txt
```

This will install the necessary packages based on the versions specified in the [`requirements.txt`](command:_github.copilot.openRelativePath?%5B%7B%22scheme%22%3A%22file%22%2C%22authority%22%3A%22%22%2C%22path%22%3A%22%2Froot%2Fboring%2Ffsd%2F2024-07-01%2Frequirements.txt%22%2C%22query%22%3A%22%22%2C%22fragment%22%3A%22%22%7D%5D "/root/boring/fsd/2024-07-01/requirements.txt") file.

## Usage

1. Run the [`age_calculator.py`](command:_github.copilot.openRelativePath?%5B%7B%22scheme%22%3A%22file%22%2C%22authority%22%3A%22%22%2C%22path%22%3A%22%2Froot%2Fboring%2Ffsd%2F2024-07-01%2Fage_calculator.py%22%2C%22query%22%3A%22%22%2C%22fragment%22%3A%22%22%7D%5D "/root/boring/fsd/2024-07-01/age_calculator.py") script using the following command:

```bash
python age_calculator.py
```

2. Follow the prompts to enter your date of birth and select a file type to save the output.
3. The output will be saved to the selected file type in the same directory as the script.