# ASP.NET API Template

Proyek ini merupakan template API sederhana menggunakan **ASP.NET Core**. Template ini menyediakan fitur CRUD untuk entitas seperti **Barang**, **Transaksi**, dan **Users** dengan integrasi database menggunakan **Entity Framework Core**.

## Fitur Utama
- **Barang**: Menyediakan endpoint untuk mengelola data barang (Get, Get by ID, Create, Update, Delete).
- **Users**: Endpoint untuk mengelola data pengguna.
- **Transaksi**: Menyediakan fitur transaksi yang mengurangi stok barang berdasarkan jumlah transaksi.

## Teknologi yang Digunakan
- **ASP.NET Core**: Framework untuk membangun API.
- **Entity Framework Core**: ORM untuk pengelolaan database.
- **Microsoft SQL Server**: Database yang digunakan.
- **Dependency Injection**: Untuk pengelolaan konteks database.

## Struktur Proyek
- **Controllers**: Berisi logika untuk mengatur permintaan API.
  - `BarangController.cs`: Mengelola endpoint untuk data barang.
  - `TransaksiController.cs`: Mengelola endpoint untuk transaksi.
  - `UsersController.cs`: Mengelola endpoint untuk data pengguna.

- **Data**: Menyediakan konfigurasi database dan konteks aplikasi.
  - `AppDbContext.cs`: Menghubungkan aplikasi dengan database.
  - **Configurations**: Berisi pengaturan spesifik untuk model.
    - `TransaksiConfiguration.cs`: Konfigurasi untuk entitas transaksi.

- **Models**: Mendefinisikan struktur data untuk entitas.
  - `BarangModel.cs`: Model untuk data barang.
  - `TransaksiModel.cs`: Model untuk data transaksi.
  - `UsersModel.cs`: Model untuk data pengguna.

- **Program.cs**: Titik masuk utama aplikasi.
- **Startup.cs**: Berisi konfigurasi aplikasi, termasuk layanan dan middleware.


## Endpoint API
### Barang
- `GET /api/Barang`: Mendapatkan daftar barang.
- `GET /api/Barang/{id}`: Mendapatkan barang berdasarkan ID.
- `POST /api/Barang`: Menambahkan barang baru.
- `PUT /api/Barang/{id}`: Mengupdate data barang berdasarkan ID.
- `DELETE /api/Barang/{id}`: Menghapus barang berdasarkan ID.

### Users
- `GET /api/Users`: Mendapatkan daftar pengguna.
- `GET /api/Users/{id}`: Mendapatkan pengguna berdasarkan ID.
- `POST /api/Users`: Menambahkan pengguna baru.
- `PUT /api/Users/{id}`: Mengupdate data pengguna berdasarkan ID.
- `DELETE /api/Users/{id}`: Menghapus pengguna berdasarkan ID.

### Transaksi
- `GET /api/Transaksi`: Mendapatkan daftar transaksi.
- `POST /api/Transaksi`: Membuat transaksi baru dan mengurangi stok barang.

## Instalasi dan Konfigurasi
1. Clone repository ini:
   ```bash
   git clone https://github.com/username/repo-name.git
## Cara Menjalankan Proyek

1. **Buka Proyek**  
   Buka proyek dengan Visual Studio atau editor lainnya.

2. **Atur Koneksi Database**  
   Atur koneksi database di file `appsettings.json`.

3. **Jalankan Perintah Migrasi**  
   Gunakan perintah berikut untuk membuat database:
   ```bash
   dotnet ef migrations add InitialCreate
   dotnet ef database update

4. **Jalankan Aplikasi**
   Gunakan perintah berikut untuk menjalankan aplikasi:
   ```bash
   dotnet run

### Kontribusi
Silakan buat Pull Request jika Anda ingin menambahkan fitur baru atau memperbaiki bug.








