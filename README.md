Project Goal
Create a backend for a Blog Application:

* Support full CRUD operations
* Allow users to create an account and log in
* Deploy to Azure
* Use SCRUM workflow concepts
* Introduce Azure DevOps practices

Stack
Backend: .NET 9, ASP.NET Core, EF Core, SQL Server
Frontend: Next.js with TypeScript and Flowbite (Tailwind)
Deployment: Vercel or Azure

Application Features

User Capabilities

* Create account
* Log in
* Delete account

Blog Features

* View all blog posts
* Filter blog posts
* Create blog post
* Edit blog post
* Delete blog post
* Publish blog post
* Unpublish blog post

Pages (Frontend connected to API)

Create Account Page

Blog View Page (published posts only)

Dashboard Page (profile page to edit, delete, publish, unpublish posts)

Blog Page

* Display all published blog posts

Dashboard Page

* User profile page
* Create blog post
* Edit blog post
* Delete blog post

Project Folder Structure

Controllers

UserController
Handles all user interactions.

Endpoints:

* Login
* Add User
* Update User
* Delete User

BlogController
Handles all blog operations.

Endpoints:

* Create Blog Item (C)
* Get All Blog Items (R)
* Get Blog Item by Category (R)
* Get Blog Item by ID (R)
* Get Blog Item by Tags (R)
* Get Blog Item by Date (R)
* Get Published Blog Items (R)
* Update Blog Item (U)
* Delete Blog Item (D)

  * Used for soft delete / publish logic

Models

UserModel
int Id
string Username
string Salt
string Hash

BlogItemModel
int Id
int UserId
string PublisherName
string Title
string Image
string Description
string Date
string Category
string Tags
bool IsPublished
bool IsDeleted

Items Saved to DB

We need authentication using username and password.

```csharp
LoginModel
    string Username
    string Password

CreateAccountModel
    int Id = 0
    string Username
    string Password

PasswordModel
    string Salt
    string Hash
```

Services

Context Folder

* DataContext

UserService

* GetUserByUsername
* Login
* AddUser
* UpdateUser
* DeleteUser

BlogItemService

* AddBlogItems
* GetAllBlogItems
* GetBlogItemByCategory
* GetBlogItemsByTags
* GetBlogItemsByDate
* GetPublishedBlogItems
* UpdateBlogItems
* DeleteBlogItems
* GetUserById

PasswordService

* HashPassword
* VerifyHash
