**Programming Principles Demonstrated**

Нижче описані принципи програмування, які видно в коді цього проєкту, з посиланнями на відповідні файли й рядки.

**Modularity / Separation of Concerns**:
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

**Configuration & Constants**:
- **Опис:** Конфігураційні значення та кольори централізовані в `GameConfig` — полегшує зміну параметрів додатку.
- **Посилання:** [_2048ClassLibrary/GameConfig.cs](_2048ClassLibrary/GameConfig.cs#L4-L12)

**Event-driven UI & Responsiveness**:
- **Опис:** Використовується `Timer` та обробники подій для оновлення часу та UI, що демонструє подійну архітектуру інтерфейсу.
- **Посилання:** [GameForm/GameForm.cs](GameForm/GameForm/GameForm.cs#L124-L126), [GameForm/GameForm.cs](GameForm/GameForm/GameForm.cs#L151-L158)

**Resource Management / Dispose Pattern**:
- **Опис:** Форма перевизначає `Dispose` для звільнення компонентів, що демонструє уважне ставлення до ресурсів.
- **Посилання:** [GameForm/GameForm.cs](GameForm/GameForm/GameForm.cs#L36-L37)

**Clear Naming & Readability**:
- **Опис:** Методичні імена (`InitializeBoard`, `UpdateUI`, `HandleVictory`, `HandleGameOver`, `ProcessCmdKey`) покращують читабельність й підтримку коду.
- **Посилання:** [GameForm/GameForm.cs](GameForm/GameForm/GameForm.cs#L102-L116), [GameForm/GameForm.cs](GameForm/GameForm/GameForm.cs#L151-L158), [GameForm/GameForm.cs](GameForm/GameForm/GameForm.cs#L168-L196)

**Testability (logic separated from UI)**:
- **Опис:** Ігрова логіка знаходиться в класі `GameBoard` без залежностей від WinForms, що спрощує написання юніт-тестів для правила злиття та руху.
- **Посилання:** [_2048ClassLibrary/GameBoard.cs](_2048ClassLibrary/GameBoard.cs#L19-L66), [_2048ClassLibrary/GameBoard.cs](_2048ClassLibrary/GameBoard.cs#L99-L105)

**Small Focused Classes (Score management)**:
- **Опис:** `ScoreCounter` демонструє принцип маленького класу з однією відповідальністю — акумулювати очки.
- **Посилання:** [_2048ClassLibrary/ScoreCounter.cs](_2048ClassLibrary/ScoreCounter.cs#L9-L15)

--
