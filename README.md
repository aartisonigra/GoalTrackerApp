# Goal Tracker Web Application

A modern, responsive web application built with ASP.NET Core MVC and C# that helps users create, manage, and track their short-term and long-term goals. Features a beautiful UI with gradient colors, animations, and professional styling.

## 🚀 Features

### Core Functionality
- **Create Goals**: Add new short-term or long-term goals with title, description, type, and target date
- **View Goals**: Display all goals in a responsive table with filtering options
- **Edit Goals**: Update goal details including progress percentage (0-100%)
- **Delete Goals**: Remove goals with confirmation dialog
- **Progress Tracking**: Visual progress bars and automatic completion marking at 100%

### Advanced Features
- **Smart Status Management**: Goals automatically marked as "Completed" when progress reaches 100%
- **Expiry Alerts**: Visual indicators for goals past their target date
- **Filtering System**: Filter goals by type (Short-term/Long-term) and status (Active/Completed)
- **Responsive Design**: Works seamlessly on desktop, tablet, and mobile devices
- **Modern UI**: Professional gradient design with smooth animations and hover effects

### Technical Features
- **JSON File Persistence**: No database required - data stored in `data/goals.json`
- **Thread-Safe Operations**: Concurrent access handling for file operations  
- **Form Validation**: Both client-side (HTML5) and server-side (DataAnnotations) validation
- **Dependency Injection**: Clean architecture with service layer pattern
- **Bootstrap Integration**: Responsive UI framework with custom CSS enhancements

## 🛠️ Technology Stack

- **Backend**: ASP.NET Core 8.0 MVC
- **Language**: C# 
- **Frontend**: Razor Views, Bootstrap 5.3, Custom CSS
- **Data Storage**: JSON file-based persistence
- **Icons**: Font Awesome 6.4
- **Development Environment**: Visual Studio Code
- **Testing Framework**: xUnit (unit tests included)

## 📋 Prerequisites

Before running this application, ensure you have:

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0) installed
- [Visual Studio Code](https://code.visualstudio.com/) (recommended)
- Git for version control (optional)

## 🚀 Quick Start

### 1. Clone or Download the Project
```bash
git clone <your-repository-url>
cd GoalTrackerApp
```

### 2. Open in VS Code
```bash
code .
```

### 3. Restore Dependencies
```bash
dotnet restore
```

### 4. Run the Application
```bash
dotnet run
```

### 5. Access the Application
Open your browser and navigate to: `http://localhost:5000/Goals`

## 📁 Project Structure

```
GoalTrackerApp/
│
├── Controllers/
│   └── GoalsController.cs          # Main controller handling CRUD operations
│
├── Models/
│   ├── Goal.cs                     # Goal data model with validation
│   └── ErrorViewModel.cs           # Error handling model
│
├── Services/
│   ├── IGoalService.cs            # Service interface
│   └── GoalService.cs             # JSON persistence service implementation
│
├── Views/
│   ├── Goals/
│   │   ├── Index.cshtml           # Goals list with filtering
│   │   ├── Create.cshtml          # Create new goal form
│   │   ├── Edit.cshtml            # Edit existing goal form
│   │   ├── Details.cshtml         # Goal details view
│   │   └── Delete.cshtml          # Delete confirmation
│   └── Shared/
│       └── _Layout.cshtml         # Main layout template
│
├── wwwroot/
│   ├── css/
│   │   ├── site.css               # Default styles
│   │   └── goaltracker.css        # Custom theme styles
│   └── js/
│       └── site.js                # Client-side scripts
│
├── data/
│   └── goals.json                 # Data storage file (auto-created)
│
├── Program.cs                     # Application entry point & DI configuration
└── GoalTrackerApp.csproj         # Project file
```

## 🎯 Usage Guide

### Creating a New Goal
1. Click "Add New Goal" button on the main page
2. Fill in the required fields:
   - **Title**: Short descriptive name (required)
   - **Description**: Detailed description (optional)
   - **Type**: Short-term or Long-term
   - **Target Date**: When you want to achieve this goal
3. Click "Save Goal"

### Managing Goals
- **View Details**: Click the "View" button to see complete goal information
- **Edit Goal**: Click "Edit" to modify title, description, progress, or status
- **Update Progress**: Use the edit form to set progress percentage (0-100%)
- **Delete Goal**: Click "Delete" and confirm to remove a goal permanently

### Filtering Goals
Use the filter section at the top of the goals list:
- **By Type**: Show only Short-term or Long-term goals
- **By Status**: Show only Active or Completed goals
- **Combined**: Apply both filters simultaneously

## 🎨 UI Features

### Color Scheme
- **Primary**: Purple-blue gradient (#6366f1 to #4f46e5)
- **Success**: Green gradient (#10b981 to #059669)  
- **Warning**: Orange gradient (#fbbf24 to #f59e0b)
- **Danger**: Pink-red gradient (#f093fb to #f5576c)

### Visual Elements
- **Progress Bars**: Animated progress indicators with percentage display
- **Status Badges**: Color-coded badges for goal types and completion status
- **Hover Effects**: Smooth animations on buttons and table rows
- **Expiry Alerts**: Pulsing red badges for overdue goals
- **Icons**: Font Awesome icons throughout the interface

## 🧪 Testing

### Manual Testing Checklist
- [ ] Create a new short-term goal
- [ ] Create a new long-term goal  
- [ ] Edit goal progress to 50%
- [ ] Edit goal progress to 100% (should auto-complete)
- [ ] Filter goals by type
- [ ] Filter goals by status
- [ ] Delete a goal
- [ ] Test responsive design on mobile

### Sample Test Data
The application will auto-create sample data or you can manually add:

1. **Goal 1**: "Complete Web Development Course"
   - Type: Short-term
   - Target: Next month
   - Progress: 75%

2. **Goal 2**: "Launch Personal Business"
   - Type: Long-term  
   - Target: Next year
   - Progress: 25%

## 🔧 Configuration

### Data Storage
Goals are stored in `data/goals.json`. The file is automatically created on first run. For hosted environments where file writing isn't available, the service can be modified to use in-memory storage only.

### Customization
- **Colors**: Modify CSS variables in `wwwroot/css/goaltracker.css`
- **Validation**: Update DataAnnotations in `Models/Goal.cs`  
- **UI Layout**: Customize views in the `Views/Goals/` folder

## 🚢 Deployment

### Local Development
```bash
dotnet run --environment Development
```

### Production Build
```bash
dotnet publish -c Release -o ./publish
```

### Azure App Service Deployment
```bash
# Using Azure CLI
az webapp create --name your-app-name --resource-group your-rg --plan your-plan
az webapp deploy --resource-group your-rg --name your-app-name --src-path ./publish
```

**Note**: For hosted environments, ensure the `data` folder has write permissions or modify the service to use in-memory storage.

## 🐛 Troubleshooting

### Common Issues

**Build Errors**: 
```bash
# Clean and rebuild
dotnet clean
dotnet build
```

**File Permission Issues**:
- Ensure the application has write access to the `data` folder
- On Linux/macOS: `chmod 755 data`

**Missing Dependencies**:
```bash
dotnet restore
```

**Port Already in Use**:
```bash
# Kill process on port 5000
netstat -ano | findstr :5000
taskkill /PID <process-id> /F
```

## 🤝 Contributing

1. Fork the repository
2. Create a feature branch (`git checkout -b feature/amazing-feature`)
3. Commit your changes (`git commit -m 'Add amazing feature'`)
4. Push to the branch (`git push origin feature/amazing-feature`)
5. Open a Pull Request

## 📝 License

This project is open source and available under the [MIT License](LICENSE).

## 👨‍💻 Developer Information

**Created by**: [Your Name]  
**Student ID**: [Your Enrollment Number]  
**Course**: Web Technologies with .NET  
**Institution**: [Your College/University]  
**Date**: October 2025

## 🔗 Additional Resources

- [ASP.NET Core Documentation](https://docs.microsoft.com/en-us/aspnet/core/)
- [Bootstrap Documentation](https://getbootstrap.com/docs/)
- [Font Awesome Icons](https://fontawesome.com/icons)
- [JSON.NET Documentation](https://www.newtonsoft.com/json/help/html/Introduction.htm)

## 📞 Support

For questions or support regarding this project:
- Create an issue in the GitHub repository
- Contact: [23amtics292@gmail.com]

---

**⭐ If you found this project helpful, please consider giving it a star!**

