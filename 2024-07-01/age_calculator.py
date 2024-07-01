import datetime
import csv
import os
from reportlab.lib.pagesizes import letter
from reportlab.platypus import SimpleDocTemplate, Table, TableStyle
from reportlab.lib import colors

class AgeCalculator:
    def __init__(self):
        pass

    def calculate_age(self, dob):
        today = datetime.date.today()
        age = today.year - dob.year - ((today.month, today.day) < (dob.month, dob.day))
        return age

    def save_output(self, dob, age, file_type):
        if file_type == 'csv':
            with open('age_data.csv', 'a', newline='') as csvfile:
                writer = csv.writer(csvfile)
                writer.writerow([dob, age])
            print("Output saved to age_data.csv")
        elif file_type == 'pdf':
            pdf_file = SimpleDocTemplate(f"age_data_{dob.strftime('%Y%m%d')}.pdf", pagesize=letter)
            data = [[dob.strftime('%Y-%m-%d'), age]]
            table = Table(data)
            table_style = TableStyle([('BACKGROUND', (0,0), (-1,0), colors.grey),
                                     ('TEXTCOLOR', (0,0), (-1,0), colors.whitesmoke),
                                     ('ALIGN', (0,0), (-1,-1), 'CENTER'),
                                     ('FONTNAME', (0,0), (-1,0), 'Helvetica-Bold'),
                                     ('FONTSIZE', (0,0), (-1,0), 14),
                                     ('BOTTOMPADDING', (0,0), (-1,0), 12),
                                     ('BACKGROUND', (0,1), (-1,-1), colors.beige),
                                     ('GRID', (0,0), (-1,-1), 1, colors.black)])
            table.setStyle(table_style)
            elements = [table]
            pdf_file.build(elements)
            print(f"Output saved to age_data_{dob.strftime('%Y%m%d')}.pdf")
        elif file_type == 'txt':
            with open('age_data.txt', 'a') as txtfile:
                txtfile.write(f"Date of Birth: {dob.strftime('%Y-%m-%d')}, Age: {age}\n")
            print("Output saved to age_data.txt")
        else:
            print("Invalid file type selected.")

def main():
    calculator = AgeCalculator()

    while True:
        dob_str = input("Enter your date of birth (YYYY-MM-DD): ")
        dob = datetime.datetime.strptime(dob_str, '%Y-%m-%d').date()
        age = calculator.calculate_age(dob)
        print(f"Your age is: {age}")

        file_type = input("Select file type to save output (csv/pdf/txt): ")
        calculator.save_output(dob, age, file_type)

        another_input = input("Do you want to enter another input? (y/n): ")
        if another_input.lower() != 'y':
            break

if __name__ == "__main__":
    main()