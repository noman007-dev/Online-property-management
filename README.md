# 🏡 Online Property Marketplace

A desktop application for buying, selling, and renting properties, built with **C# Windows Forms** and **Microsoft SQL Server**. It supports three roles (Buyer, Seller, and Admin), each with its own dashboard.

![C#](https://img.shields.io/badge/C%23-.NET%20Framework%204.7.2-512BD4)
![Platform](https://img.shields.io/badge/platform-Windows-0078D6)
![Database](https://img.shields.io/badge/database-SQL%20Server%20Express-CC2927)

---

## ✨ Features

### 👤 Buyer
- Browse available properties with images, price, and description
- Search by title, address, description, or price
- Filter by **Sell / Rent** and by **category**
- Save properties to a **wishlist**
- Purchase a property and choose a payment method (bKash, VISA, MasterCard, PayPal)
- Message sellers about a property
- View purchase history and notifications
- Edit profile

### 🏠 Seller
- List a new property with title, address, price, category, Rent/Sell type, description, and photo
- View and delete available listings
- Read messages from interested buyers
- View sales history and notifications
- Edit profile

### 🛠️ Admin
- Dashboard with totals for properties, sellers, buyers, and transactions
- Manage users: search, add, and delete
- Manage properties: search and delete (sold properties are protected from deletion)
- Manage property categories (a category still in use cannot be deleted)
- View and manage the full transaction history

### 🔐 General
- Role-based login (Buyer / Seller / Admin)
- Sign up as Buyer or Seller
- Forgot-password flow
- Built-in user guide for each role

---

## 🧰 Tech Stack

| Layer | Technology |
|-------|------------|
| Language | C# |
| UI | Windows Forms (WinForms) |
| Framework | .NET Framework 4.7.2 |
| Database | Microsoft SQL Server (Express) |
| Data access | ADO.NET (`System.Data.SqlClient`) with parameterized queries |
| IDE | Visual Studio 2022 |

---

## 🗄️ Database Schema

Database name: `login`

| Table | Purpose |
|-------|---------|
| `logindata` | Users (Id, Name, Email, Phone, Password, Role) |
| `logincategories` | Property categories |
| `loginproperties` | Property listings (seller, category, price, Rent/Sell, image, status) |
| `buyerproperties` | Properties a buyer has purchased |
| `logintransactions` | Transaction records (buyer, seller, property, amount, date) |
| `Wishlist` | Buyer wishlists |
| `Messages` | Buyer-to-seller messages |
| `Notifications` | Per-user notifications |

---

## 🚀 Getting Started

### Prerequisites
- Windows 10 or 11
- [Visual Studio 2022](https://visualstudio.microsoft.com/) with the **.NET desktop development** workload
- Microsoft SQL Server Express (an instance named `SQLEXPRESS`) and SQL Server Management Studio (SSMS)

### 1. Clone the repository
```bash
git clone https://github.com/noman007-dev/Online-property-management-C--.git
cd Online-property-management-C--
```

### 2. Extract the source code
The project source is packaged in `Online Property Marketplace.rar`. Extract it with WinRAR or 7-Zip. The Visual Studio solution is `WindowsFormsApp3.sln`.

### 3. Set up the database
1. Open `database.sql` in SSMS.
2. The script creates the `login` database with hard-coded file paths (`C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\`). **Edit these paths to match your SQL Server version**, or replace the `CREATE DATABASE` block with a plain `CREATE DATABASE [login]`.
3. Run the script to create all tables.
4. Add an admin account and a few categories, since the script contains no seed data:

```sql
USE [login];

INSERT INTO logindata (Name, Email, Phone, Password, Role)
VALUES ('admin', 'admin@example.com', '0123456789', 'admin123', 'Admin');

INSERT INTO logincategories (CategoryName)
VALUES ('House'), ('Apartment'), ('Land'), ('Commercial');
```

### 4. Check the connection string
Open `DbConnection.cs` and make sure it matches your SQL Server instance:

```csharp
public static string connectionString =
    "data source=.\\SQLEXPRESS; database=login; integrated security=SSPI";
```

### 5. Build and run
Open `WindowsFormsApp3.sln` in Visual Studio and press **F5**. The app starts on the login screen.

---

## 📖 Usage

1. **Sign up** as a Buyer or Seller, or log in with the admin account you created.
2. **Sellers** add listings from *Add Property*. Listings appear to buyers once saved.
3. **Buyers** browse, search, filter, wishlist, message sellers, and purchase.
4. A purchase marks the property as **Sold**, records a transaction, removes it from the wishlist, and notifies both parties.
5. **Admins** monitor users, properties, categories, and transactions.

---

## 📁 Project Structure

```
Online-property-management-C--/
├── database.sql                       # SQL Server schema
├── Online Property Marketplace.rar    # Full Visual Studio solution
└── WindowsFormsApp3/
    ├── LoginForm.cs / SignupForm.cs / ForgetPasswordForm.cs
    ├── Buyer*Form.cs, WishlistForm.cs, ViewPropertyForm.cs
    ├── Seller*Form.cs
    ├── Admin*Form.cs
    ├── NotificationForm.cs
    ├── DbConnection.cs                # Connection string
    ├── Program.cs                     # Entry point
    └── Resources/                     # Images used by the UI
```

---

## ⚠️ Known Limitations

This is a learning project, so a few things are not production-ready:

- **Passwords are stored in plain text.** Hash them (for example with BCrypt or PBKDF2) before any real use.
- **Password reset only checks the email address**, with no verification step.
- **Payments are simulated.** The payment method is selected but no real payment is processed.
- **Windows only**, since it relies on WinForms.

## 🛣️ Possible Improvements

- Password hashing and email-verified password reset
- Real payment gateway integration
- Image gallery with multiple photos per property
- Map view and location-based search
- Migration to ASP.NET Core or a web front end

---

## 👨‍💻 Author

**Noman**, GitHub: [@noman007-dev](https://github.com/noman007-dev)

## 📄 License

No license has been specified yet. Add a `LICENSE` file (for example MIT) if you want others to reuse this project.
