
# 🎮 Data Persistence Project – Unity  
**A Breakout-Style Game Implemented With Scene & Session Data Saving**

![Unity](https://img.shields.io/badge/Engine-Unity-blue?style=for-the-badge&logo=unity)
![Language](https://img.shields.io/badge/Language-C%23-green?style=for-the-badge&logo=c-sharp)
![Status](https://img.shields.io/badge/Status-Completed-brightgreen?style=for-the-badge)
[![LinkedIn](https://img.shields.io/badge/Tejay%20Pardeep-LinkedIn-blue?style=for-the-badge&logo=linkedin)](https://www.linkedin.com/in/tejay-pardeep/)

---

## 💡 Overview

This project is a **Unity breakout-style game** focused on implementing:

- **Data persistence between scenes**
- **Data persistence between sessions**

The player enters their name in the **Start Menu**, plays the game, and the **best score is saved permanently** using JSON.

---

## ⚙️ Key Features Implemented

### 🔄 Data Persistence Between Scenes
- Player enters name in **Start Menu**
- Name shows up in **Main Game** scene
- Smooth scene transitions

### 💾 Data Persistence Between Sessions
- High score + player name saved using JSON
- Data automatically loads when the game starts
- New high score updates immediately

### 🎮 Gameplay Features
- Classic breakout mechanics
- Real-time score system
- Brick destruction and physics-based ball movement

---

## 🧠 What I Learned

- Using **Singletons** for global game data  
- Implementing **JSON serialization**  
- Managing **scene flow** in Unity  
- Saving & loading **persistent data**  
- Building UI for player name + score display  

---

## 📸 Demo Video

!https://github.com/user-attachments/assets/ab32a679-0e82-46ca-a76a-2b3ea8e6f210

---

## 📁 Project Structure

```
Assets/
├── Scripts/
│   ├── MainManager.cs
│   ├── UIHandler.cs
│   ├── Ball.cs
│   ├── Brick.cs
│   └── Paddle.cs
├── Scenes/
│   ├── StartMenu.unity
│   └── Main.unity
└── Prefabs/
```

---

## 🎯 Possible Improvements

- Multiple high score leaderboard  
- Settings menu (volume, difficulty, etc.)  
- Better visual effects & sound  
- Achievements system  

---

## 🧩 Tools Used

- **Unity 2020.3 LTS**
- **C#**
- **JSON Serialization**
- **Unity UI**
- **Scene Management**

---

## 💬 Connect With Me

Let’s connect and share ideas:  
👉 **[LinkedIn](https://www.linkedin.com/in/tejay-pardeep/)**

---

⭐ *If you found this project helpful, consider starring the repo!*
