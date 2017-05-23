using UnityEngine;
using UnityEngine.UI;

public class TextController : MonoBehaviour {

	public Text text;
    private enum States {cell, mirror, sheets_0, lock_0, cell_mirror, sheets_1, lock_1, corridor_0, floor, stairs_0, closet_door, stairs_1, corridor_1, in_closet, corridor_2, stairs_2, corridor_3, courtyard};
    private States myState;

	// Use this for initialization
	void Start () {
        myState = States.cell;
	}
	
	// Update is called once per frame
	void Update () {
        print(myState);
        if      (myState == States.cell)            { cell(); }
        else if (myState == States.sheets_0)        { sheets_0(); }
        else if (myState == States.sheets_1)        { sheets_1(); }
        else if (myState == States.lock_0)          { lock_0(); }
        else if (myState == States.lock_1)          { lock_1(); }
        else if (myState == States.mirror)          { mirror(); }
        else if (myState == States.cell_mirror)     { cell_mirror(); }
        else if (myState == States.corridor_0)      { corridor_0(); }
        else if (myState == States.floor)           { floor(); }
        else if (myState == States.stairs_0)        { stairs_0(); }
        else if (myState == States.stairs_1)        { stairs_1(); }
        else if (myState == States.stairs_2)        { stairs_2(); }
        else if (myState == States.closet_door)     { closet_door(); }
        else if (myState == States.corridor_1)      { corridor_1(); }
        else if (myState == States.corridor_2)      { corridor_2(); }
        else if (myState == States.corridor_3)      { corridor_3(); }
        else if (myState == States.in_closet)       { in_closet(); }      
        else if (myState == States.courtyard)       { courtyard(); }

    }

    void cell()
    {
        text.text = "You are in a prison cell. You are unable to leave, as the door is locked from the outside. You see a bed with dirty sheets, a mirror on the wall, and the cell door (locked). How do you wish to proceed?\n\nPress S to view Sheets, M to view the Mirror, or L to examine the Lock.";

        if (Input.GetKeyDown(KeyCode.S))                { myState = States.sheets_0; }
        else if (Input.GetKeyDown(KeyCode.M))           { myState = States.mirror; }
        else if (Input.GetKeyDown(KeyCode.L))           { myState = States.lock_0; }
    }

    void sheets_0()
    {
        text.text = "These are filthy, I can't believe anyone would be able to sleep in them. I guess room service isn't a thing here.\n\nPress R to Return to your cell.";

        if (Input.GetKeyDown(KeyCode.R))                { myState = States.cell; }
    }

    void sheets_1()
    {
        text.text = "The sheets look the same as before, but mirrored now. The realization that you'll never get the time back you've wasted on this little excursion makes you accutely aware of your own mortality and you decide to sit down for a bit and think about some heavy stuff.\n\nPress R to repress your feelings and Return to your cell.";
        if (Input.GetKeyDown(KeyCode.R))                { myState = States.cell_mirror; }
    }

    void lock_0()
    {
        text.text = "It appears to be a combination lock, but I have no idea what the combination for it would be. Maybe if there was some way to see the fingerprints on it from all the dust...\n\nPress R to Return to your cell.";
        if (Input.GetKeyDown(KeyCode.R))                { myState = States.cell; }
    }

    void lock_1()
    {
        text.text = "You jimmy the mirror through the bars in the door and position it so you can get a better look at this lock. You start to get the combination, letter by letter. 'S' 'W' 'O' 'R' 'D' 'F' 'I' 'S' - Oh come on now. You become relieved that no one was around to see this. You really should have just tried that at the start. Oh well...\n\n Press O to Open the door, or press R to Return to your cell (for some reason).";
        if (Input.GetKeyDown(KeyCode.R))                { myState = States.cell_mirror; }
        else if (Input.GetKeyDown(KeyCode.O))           { myState = States.corridor_0; }
    }

    void mirror()
    {
        text.text = "The mirror on the wall seems loose. I bet I could get some good use out of it...\n\nPress T to Take the mirror, or R to Return to your cell.";
        if (Input.GetKeyDown(KeyCode.T))                { myState = States.cell_mirror; }
        else if (Input.GetKeyDown(KeyCode.R))           { myState = States.cell; }
    }

    void cell_mirror()
    {
        text.text = "With your new partner in crime, you get a new perspective on life! (And really anything you desire, it's a mirror after all.)\n\nPress S to take a look at your Sheets, or press L to take a Looksie-Loo at the ol' Lock.";
        if (Input.GetKeyDown(KeyCode.S))                { myState = States.sheets_1; }
        else if (Input.GetKeyDown(KeyCode.L))           { myState = States.lock_1; }
    }

    void corridor_0()
    {
        text.text = "You see a poorly lit hallway. No one is around, but you shouldn't stick around for longer than you have to. You see some Stairs and a nearby Closet. You could also see if there's anything of use on the Floor...\n\nPress S to go up the Stairs, C to take a look at the Closet, or F to examine the Floor";

        if(Input.GetKeyDown(KeyCode.S))                 { myState = States.stairs_0; }
        else if(Input.GetKeyDown(KeyCode.C))            { myState = States.closet_door; }
        else if(Input.GetKeyDown(KeyCode.F))            { myState = States.floor; }
    }

    void stairs_0()
    {
        text.text = "You go up the stairs, but hear sounds of activity and distant voices. It would be unwise to go this way.\n\nPress R to head back down and Return to the hallway.";

        if (Input.GetKeyDown(KeyCode.R)) { myState = States.corridor_0; }
    }

    void closet_door()
    {
        text.text = "A locked closet door. Not combination lock either, you're going to need a key or to improvise to get this open.\n\nPress R to Return to the hallway.";

        if (Input.GetKeyDown(KeyCode.R)) { myState = States.corridor_0; }
    }

    void floor()
    {
        text.text = "Yep, that's a floor alright. You see a Hairclip on the ground.\n\nPress H to take the Hairclip, press R to Return.";

        if (Input.GetKeyDown(KeyCode.H)) { myState = States.corridor_1; }
        else if (Input.GetKeyDown(KeyCode.R)) { myState = States.corridor_0; }

    }

    void corridor_1()
    {
        text.text = "Wielding your new tool, an endless world of possibilities opens up to you. Sadly you're not too bright, so you can only think of two.\n\nPress P to Pick the lock on the closet door, press S to have a go at the stairs.";

        if (Input.GetKeyDown(KeyCode.P)) { myState = States.in_closet; }
        else if (Input.GetKeyDown(KeyCode.S)) { myState = States.stairs_1; }
    }

    void stairs_1()
    {
        text.text = "After some thought, you figure a hairclip wouldn't suffice as a weapon well enough to justify going this way.\n\nPress R to Return";

        if (Input.GetKeyDown(KeyCode.R)) { myState = States.corridor_1; }
    }

    void in_closet()
    {
        text.text = "Compared to your cell this is a step up, but you'd rather take your leave of this place rather than set up shop here. You do notice a janitor's outfit that gives you a hankering to play dress-up...\n\nPress D to Dress up, press R to return outside.";

        if (Input.GetKeyDown(KeyCode.D)) { myState = States.corridor_3; }
        else if (Input.GetKeyDown(KeyCode.R)) { myState = States.corridor_2; }
    }

    void corridor_2()
    {
        text.text = "Well here we are again. You get the idea you may have missed something fairly important...\n\nPress S to go up the Stairs, press C to go back in the Closet.";

        if (Input.GetKeyDown(KeyCode.S)) { myState = States.stairs_2; }
        else if (Input.GetKeyDown(KeyCode.C)) { myState = States.in_closet; }
    }

    void stairs_2()
    {
        text.text = "You have a strong nagging feeling that you're wasting everyone's time.\n\nPress R to Return";

        if (Input.GetKeyDown(KeyCode.R)) { myState = States.corridor_2; }
    }

    void corridor_3()
    {
        text.text = "Wearing your fancy boy janitor's outfit, you strut about the hallway. While ripping off that one Madonna song, you notice a nearby courtyard that you didn't see before.\n\nPress T to do a little Turn out the courtyard, press G to slip into something a little less Gauche.";

        if (Input.GetKeyDown(KeyCode.T)) { myState = States.courtyard; }
        else if (Input.GetKeyDown(KeyCode.G)) { myState = States.in_closet; }
    }

    void courtyard()
    {
        text.text = "Those in the courtyard are absolutely staggered by your sashay and break into light applause. You strut right on out the door and blow this popsicle stand.\n\n You are winner! Congraudulations!\n\nPress P to Play again.";

        if (Input.GetKeyDown(KeyCode.P)) { myState = States.cell; }
    }
}
