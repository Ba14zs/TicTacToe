# 🎮 Tic-Tac-Toe by Ba14zs

A simple **terminal-based Tic-Tac-Toe game** with an **AI opponent**, written in **C#**.  
Fully cross-platform — runs on **Windows**, **Linux**, and **macOS**.

---

## 🧠 Gameplay

- You play as **X**, the AI plays as **O**.
- The board is indexed from **0 to 8**.
- Your goal is to get three in a row — horizontally, vertically, or diagonally.
- The AI uses the **minimax algorithm**, so it’s not easy to beat 😏

---

## ⚙️ Requirements

If you’re not using a standalone build, make sure you have **.NET 8 SDK or Runtime** installed.

### Windows:
Download from the official website:  
👉 [https://dotnet.microsoft.com/download](https://dotnet.microsoft.com/download)

### Fedora

sudo dnf install dotnet-sdk-9.0

macOS:

brew install dotnet

▶️ Run from Source

git clone https://github.com/Ba14zs/TicTacToe.git
cd TicTacToe
dotnet run

🧱 Build Instructions
Debug build (for development)

dotnet build

Release build (optimized version)

dotnet publish -c Release

💾 Standalone Executables

In the donwloaded zip, you have to select your os (.7z file) then publish, then the executable

🕹️ How to Play

When you start the game:

    Choose whether you or the AI goes first.

    Enter a number (0–8) to place your move.

    Try to beat the bot — good luck! 😄

📦 Directory Structure

TicTacToe/
├── Program.cs
├── TicTacToe.csproj
├── bin/
├── obj/
└── README.md

    Note: You can safely ignore the bin/ and obj/ folders in your GitHub repo.
    Add a .gitignore file containing:

    bin/
    obj/

🧑‍💻 Author

Developed by Ba14zs
