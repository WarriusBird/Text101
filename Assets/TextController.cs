using UnityEngine;
using UnityEngine.UI;

public class TextController : MonoBehaviour {

	public Text text;
    private enum States {cell, mirror, sheets_0, lock_0, cell_mirror, sheets_1, lock_1, freedom};
    private States myState;

	// Use this for initialization
	void Start () {
        myState = States.cell;
	}
	
	// Update is called once per frame
	void Update () {
        print(myState);
        if(myState == States.cell)                  { state_cell(); }
        else if(myState == States.sheets_0)         { state_sheets_0(); }
        else if(myState == States.sheets_1)         { state_sheets_1(); }
        else if (myState == States.lock_0)          { state_lock_0(); }
        else if (myState == States.lock_1)          { state_lock_1(); }
        else if (myState == States.mirror)          { state_mirror(); }
        else if (myState == States.cell_mirror)     { state_cell_mirror(); }
        else if (myState == States.freedom)         { state_freedom(); }

    }

    void state_cell()
    {
        text.text = "You are in a prison cell. You are unable to leave, as the door is locked from the outside. You see a bed with dirty sheets, a mirror on the wall, and the cell door (locked). How do you wish to proceed?\n\nPress S to view Sheets, M to view the Mirror, or L to examine the Lock.";

        if (Input.GetKeyDown(KeyCode.S))                { myState = States.sheets_0; }
        else if (Input.GetKeyDown(KeyCode.M))           { myState = States.mirror; }
        else if (Input.GetKeyDown(KeyCode.L))           { myState = States.lock_0; }
    }

    void state_sheets_0()
    {
        text.text = "These are filthy, I can't believe anyone would be able to sleep in them. I guess room service isn't a thing here.\n\nPress R to Return to your cell.";

        if (Input.GetKeyDown(KeyCode.R))                { myState = States.cell; }
    }

    void state_sheets_1()
    {
        text.text = "The sheets look the same as before, but mirrored now. The realization that you'll never get the time back you've wasted on this little excursion makes you accutely aware of your own mortality and you decide to sit down for a bit and think about some heavy stuff.\n\nPress R to repress your feelings and Return to your cell.";
        if (Input.GetKeyDown(KeyCode.R))                { myState = States.cell_mirror; }
    }

    void state_lock_0()
    {
        text.text = "It appears to be a combination lock, but I have no idea what the combination for it would be. Maybe if there was some way to see the fingerprints on it from all the dust...\n\nPress R to Return to your cell.";
        if (Input.GetKeyDown(KeyCode.R))                { myState = States.cell; }
    }

    void state_lock_1()
    {
        text.text = "You jimmy the mirror through the bars in the door and position it so you can get a better look at this lock. You start to get the combination, letter by letter. 'S' 'W' 'O' 'R' 'D' 'F' 'I' 'S' - Oh come on now. You become relieved that no one was around to see this. You really should have just tried that at the start. Oh well...\n\n Press O to Open the door, or press R to Return to your cell (for some reason).";
        if (Input.GetKeyDown(KeyCode.R))                { myState = States.cell_mirror; }
        else if (Input.GetKeyDown(KeyCode.O))           { myState = States.freedom; }
    }

    void state_mirror()
    {
        text.text = "The mirror on the wall seems loose. I bet I could get some good use out of it...\n\nPress T to Take the mirror, or R to Return to your cell.";
        if (Input.GetKeyDown(KeyCode.T))                { myState = States.cell_mirror; }
        else if (Input.GetKeyDown(KeyCode.R))           { myState = States.cell; }
    }

    void state_cell_mirror()
    {
        text.text = "With your new partner in crime, you get a new perspective on life! (And really anything you desire, it's a mirror after all.)\n\nPress S to take a look at your Sheets, or press L to take a Looksie-Loo at the ol' Lock.";
        if (Input.GetKeyDown(KeyCode.S))                { myState = States.sheets_1; }
        else if (Input.GetKeyDown(KeyCode.L))           { myState = States.lock_1; }
    }

    void state_freedom()
    {
        text.text = "You quickly book it out of there to notify the management of their lackluster decor and lacking security policies. You also might just leave, I dunno; I'm not your mom.\n\n You are winner! Congradulations!!\n\nPress P to Play again.";

        if(Input.GetKeyDown(KeyCode.P))                 { myState = States.cell; }
    }
}
