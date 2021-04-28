using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TasksScript : MonoBehaviour
{
    public Dictionary<string, bool> tasksStatus = new Dictionary<string, bool>();

    public Text[] taskBoard;

    //tasksdescription
    private const string creditCardEntered = "Order Taxi";
    private const string safeOpened = "Get Card From Safe";
    private const string foodEaten = "Eat Food";
    private const string catFed = "Feed Cat";
    private const string watchTV = "Watch TV";
    private const string openWindows = "Open Windows";
    private const string openTaxiApp = "Open Taxi App";

    public int foodCount;
    public const int foodMax = 7;

    public int openedWindows;

    public static event Action OnTasksFinished;

    private void Start()
    {
        openedWindows = 0;
        foodCount = 0;
        fillTasksStatus();

        Door.OnCheckiIfDoorIsLocked += CheckIfTasksFinished;

        TaxiUI.OnCorrectPasswordInput += CreditCardEntered;
        Safe.OnSafeOpened += SafeOpen;
        Food.onEaten += FoodEaten;
        CatBowl.onCatFed += CatFed;
        OutputRemoteTV.onTVturnedOn += WatchTV;
        WindowInteract.onWindowOpen += WindowOpen;
        WindowInteract.onWindowClose += WindowClosed;
        BreakableWindow.onWindowBreak += WindowOpen;

        TaxiUI.OnTaxiAppOpened += TaxiAppOpened;
    }

    public void fillTasksStatus()
    {
        if (tasksStatus.Count == 0)
        {
            tasksStatus.Add(creditCardEntered, false);
            tasksStatus.Add(safeOpened, false);
            tasksStatus.Add(foodEaten, false);
            tasksStatus.Add(catFed, false);
            tasksStatus.Add(watchTV, false);
            tasksStatus.Add(openWindows, false);
            tasksStatus.Add(openTaxiApp, false);
        }
        else
            UpdateFields();
    }

    public void UpdateFields()
    {
        taskBoard[0].text = foodEaten + $"{(tasksStatus[foodEaten] ? " V" : " X")}";
        taskBoard[1].text = catFed + $"{(tasksStatus[catFed] ? " V" : " X")}";
        taskBoard[2].text = watchTV + $"{(tasksStatus[watchTV] ? " V" : " X")}";
        taskBoard[3].text = creditCardEntered + $"{(tasksStatus[creditCardEntered] ? " V" : " X")}";
        taskBoard[4].text = $"{(tasksStatus[watchTV] ? openWindows + (tasksStatus[openWindows] ? " V" : " X") : "?")}";
        taskBoard[5].text = $"{(tasksStatus[openTaxiApp] ? safeOpened + (tasksStatus[safeOpened] ? " V" : " X") : "?")}";
    }

    public void SafeOpen()
    {
        tasksStatus[safeOpened] = true;
        taskBoard[5].text = safeOpened + " V";
    }

    public void CreditCardEntered()
    {
        tasksStatus[creditCardEntered] = true;
        taskBoard[3].text = creditCardEntered + " V";
    }

    public void TaxiAppOpened()
    {
        tasksStatus[openTaxiApp] = true;
        taskBoard[5].text = safeOpened + $"{(tasksStatus[safeOpened] ? " V" : " X")}";
    }


    public void FoodEaten()
    {   if (foodCount == foodMax)
        {
            tasksStatus[foodEaten] = true;
            taskBoard[0].text = foodEaten + " V";
        }
        else
            foodCount++;
    }

    public void CatFed()
    {
        tasksStatus[catFed] = true;
        taskBoard[1].text = catFed + " V";
    }

    public void WatchTV()
    {
        tasksStatus[watchTV] = true;
        taskBoard[2].text = watchTV + " V";
        taskBoard[4].text = openWindows + $"{(tasksStatus[openWindows]? " V" : " X")}";
    }

    public void WindowOpen()
    {
        openedWindows++;
        CheckIfEnoughWindows();

    }

    public void WindowClosed()
    {
        openedWindows--;
    }

    public void CheckIfEnoughWindows()
    {
        if(openedWindows >= 2)
        {
            taskBoard[4].text = openWindows + " V";
            tasksStatus[openWindows] = true;
        }
    }

    public void CheckIfTasksFinished()
    {
        if (tasksStatus[creditCardEntered]
            && tasksStatus[safeOpened]
            && tasksStatus[foodEaten]
            && tasksStatus[catFed]
            && tasksStatus[watchTV]
            && tasksStatus[openWindows])
        {
            OnTasksFinished?.Invoke();
        }
    }

    private void OnDestroy()
    {
        Door.OnCheckiIfDoorIsLocked -= CheckIfTasksFinished;

        TaxiUI.OnCorrectPasswordInput -= CreditCardEntered;
        Safe.OnSafeOpened -= SafeOpen;
        Food.onEaten -= FoodEaten;
        CatBowl.onCatFed -= CatFed;
        OutputRemoteTV.onTVturnedOn -= WatchTV;
        WindowInteract.onWindowOpen -= WindowOpen;
        WindowInteract.onWindowClose -= WindowClosed;
        BreakableWindow.onWindowBreak -= WindowOpen;

        TaxiUI.OnTaxiAppOpened -= TaxiAppOpened;
    }

}
