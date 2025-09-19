/*
    ~~ (A1) Main Menu ~~
    Title = LMer
    Subtitle = "Shh! Be vewy, vewy quiet.  We're hunting habits!"
    Type = SELECTION PROMPT
    Menu Choices = 
    {
        (B1) Create a New Habit Tracker
        (C1) View Habit Tracker
        (D1) Exit Program
    }

    ~~ (A2) Create New Habit Tracker ~~
    Title = Create A Habit
    Type = Selection Prompt
    Include Instruction Set
        ~ Instructions ~
        First, you will set a name for the habit.
        Then, you will be able to set custom unit of measurements for this habit.
        You will also be able to select a unit of measurement that those may be converted to.

    Ability to type ? to get additional detailed information about which step you are on.
    Menu Choices = 
    {
        (B2.1) Habit Name
        (B2.2) Add Unit of Measuerement (Selection Menu)
            (B2.2.1) Use Existing Measurements (Selection Menu)
                Existing Measuerments Table
                    Measurement Name    Converts To    

        (B2.2.2) Create New Unit of Measurement (Selection Menu)
            (B2.2.1) Measurement Name
            (B2.2.2) Add Measurement Conversion (Selection Menu)
                (B2.2.2.1) None
                (B2.2.2.2) Choose Existing Measurement
                    (B2.2.2.3) Measurement Conversion Factor  

        (B2.3) Edit or Delete Unit of Measurement (Only the ones created during this instance)
            (B3.3.1) Edit
            (B3.3.2) Delete 
                (B3.3.2.1) Type Yes to Confirm
    }

    ~~ (C1) View Habit Tracker ~~
    Title = "Select a Habit Log to View"
    Menu Choices = Habit Names

    Select a Habit Log to View
       ~ Sleeping
       ~ Eating
       ~ Coding
       ~ Hydration


    ~~~ Tables ~~~

    ~ HABITS ~
    - HabitId INTEGER PRIMARY KEY AUTOINCREMENT
    - HabitName TEXT
    
    HabitID     HabitName
    1           Sleeping
    2           Eating
    3           Coding
    4           Hydration
    


    ~ MEASUREMENTS ~
    - MeasurementId INTEGER PRIMARY KEY AUTOINCREMENT
    - MeasurementName TEXT
    - MeasurementUnit TEXT
    - CanConvert BOOL

    MeasurementId   MeasurementName     MeasurementUnit     CanConvert   
    1               Minutes             REAL                TRUE  
    2               Hours               REAL                TRUE           
    3               Calories            REAL                FALSE
    4               Ounces              REAL                TRUE
    5               Glasses             REAL                TRUE
    6               Bottles             REAL                TRUE
    7               Large Bottles       REAL                TRUE

    ~ Conversions ~ (Made from Create View)

    ConversionId    ConvertsFrom    ConvertsFromName     ConvertsTo     ConvertsToName      Factor     
    1               1               Minutes              2              Hours               60    
    2               2               Hours                1              Minutes             1/60    


*/