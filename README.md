# Attendance Management System (C# WinForms + SQL Server)

A Windows Forms application for managing student attendance in a university environment.
The system supports multiple roles (**Admin/Secretary**, **Instructor**, **Student**) and uses a SQL Server database with stored procedures to manage academic data, schedules, student cards, attendance, and reports.

## Main Roles & Capabilities

### Admin / Secretary
- Manage core academic entities:
  - Academic years, departments, subjects, rooms, schedules
  - Users (students/instructors/admin)
  - Learning groups and assigning students to groups
  - Instructor assignments (instructor ↔ subject ↔ group ↔ department)
- Manage student identification cards (unique card number per student)
- Maintain data using SQL Server stored procedures for consistency and performance.

### Instructor
- View personal schedule and assigned teaching groups/subjects
- Open a **live class session** (simulated via TCP server) so students can check in using their card number
- Monitor attendance in real time and adjust student status (Present/Absent/Justified)
- Generate attendance-related reports (daily / by group-subject), and schedule reports

### Student
- Identify using a **student card number**
- See available open sessions for their group and perform **check-in** to mark attendance
- View personal attendance status per subject

## Key Features

- **SQL Server database design** for academic years, users, groups, schedule, cards, attendance, and open sessions
- **Stored procedures** for insert/update operations (e.g., users, subjects, departments, groups, schedules, student cards)
- **Live attendance check-in** using a TCP server (instructor opens/closes a session; students check in by card number)
- **Reports (RDLC)** for schedule and attendance data

## Tech Stack

- C# (.NET) Windows Forms
- SQL Server (ADO.NET: `SqlConnection`, `SqlCommand`, `SqlDataAdapter`, `SqlDataReader`)
- RDLC ReportViewer

## Repository Structure 

- `database/FinalProjectScript.sql` — SQL Server script to create DB objects (tables, procedures, etc.)
- `src/` (or solution root) — WinForms project source code
- `Reports/` or `NewReports/` — RDLC report files (if included)

## Setup Instructions

### 1) Database Setup (SQL Server)
1. Open **SQL Server Management Studio (SSMS)**
2. Create a database (e.g., `FinalProject`)
3. Run the script:
   - `database/FinalProjectScript.sql`

This will create the required tables/procedures used by the application.

### 2) Configure Connection String
In the WinForms project, locate the connection string (commonly stored in something like `GlobalData.globalConnString` or `App.config`)
and update it to match your SQL Server instance and database name.

Example (adjust to your environment):
```txt
Server=.\SQLEXPRESS;Database=FinalProject;Trusted_Connection=True;



<img width="1378" height="684" alt="image" src="https://github.com/user-attachments/assets/ae447798-4e75-45ee-9e9a-754913226a7f" />
<img width="767" height="519" alt="image" src="https://github.com/user-attachments/assets/7743a109-8071-4781-8c54-a925665c4887" />



