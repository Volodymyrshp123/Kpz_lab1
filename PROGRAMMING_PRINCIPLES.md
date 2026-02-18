**Programming Principles Demonstrated**

Нижче описані принципи програмування, які видно в коді цього проєкту, з посиланнями на відповідні файли й рядки.

**Separation of Concerns**:
- **Опис:** Логіка гри винесена в бібліотеку, UI — у форму; це розділяє відповідальності та полегшує підтримку.
- **Посилання:** [_2048ClassLibrary/GameBoard.cs](_2048ClassLibrary/GameBoard.cs#L6-L19), [GameForm/Program.cs](GameForm/GameForm/Program.cs#L13)

**Encapsulation**:
- **Опис:** Внутрішній стан ігрової дошки прихований через приватний сеттер, прямий доступ контролюється методами класу.
- **Посилання:** [_2048ClassLibrary/GameBoard.cs](_2048ClassLibrary/GameBoard.cs#L8-L8)

**Single Responsibility (SRP)**:
- **Опис:** Кожен клас має чітку відповідальність: `GameBoard` — логіка дошки, `ScoreCounter` — підрахунок очок, `MainForm` — UI.
- **Посилання:** [_2048ClassLibrary/GameBoard.cs](_2048ClassLibrary/GameBoard.cs#L6-L19), [_2048ClassLibrary/ScoreCounter.cs](_2048ClassLibrary/ScoreCounter.cs#L9-L15), [GameForm/GameForm.cs](GameForm/GameForm/GameForm.cs#L10-L33)

**DRY / Reuse**:
- **Опис:** Поворот дошки винесено в окремий метод `RotateBoard`, який повторно використовується для реалізації всіх напрямків руху.
- **Посилання:** [_2048ClassLibrary/GameBoard.cs](_2048ClassLibrary/GameBoard.cs#L115-L122), [_2048ClassLibrary/GameBoard.cs](_2048ClassLibrary/GameBoard.cs#L73-L81)

**Event-driven UI & Responsiveness**:
- **Опис:** Використовується `Timer` та обробники подій для оновлення часу та UI, що демонструє подійну архітектуру інтерфейсу.
- **Посилання:** [GameForm/GameForm.cs](GameForm/GameForm/GameForm.cs#L124-L126), [GameForm/GameForm.cs](GameForm/GameForm/GameForm.cs#L151-L158)
