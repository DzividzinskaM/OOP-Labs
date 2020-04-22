using System;
using LibLab3;

namespace lab3
{
    class Program
    {
        static void Main(string[] args)
        {
            Weapon weaponAll = new Weapon();
            AllActors actorAll = new AllActors();
            History history = new History();


            WeaponUnion weaponGun = new WeaponUnion("gun", 10, 10);
            WeaponUnion weaponPistol = new WeaponUnion("pistol", 15, 5);
            weaponAll.weaponsList.Add(weaponGun);
            weaponAll.weaponsList.Add(weaponPistol);


            Actor actor1 = new Actor(0, 0, weaponGun);
            Actor actor2 = new Actor(10, 0, weaponPistol);
            actorAll.actorsLst.Add(actor1);
            actorAll.actorsLst.Add(actor2);



            Console.WriteLine("Start states of actors");
            Console.WriteLine();
            showInfo(actor1);
            Console.WriteLine();
            showInfo(actor2);


            history.GameHistory.Push(actor1.Save());


            actor1.goUp(30);
            actor2.fight(actor1, actorAll);
            actor1.goRight(50);

            history.GameHistory.Push(actor1.Save());
            history.GameHistory.Push(actor2.Save());

            Console.WriteLine();
            Console.WriteLine("**********************States after 1 fight");
            Console.WriteLine();
            showInfo(actor1);
            Console.WriteLine();
            showInfo(actor2);

            actor1.changeWeapon(weaponPistol, weaponAll);
            actor1.fight(actor2, actorAll);


            Console.WriteLine();
            Console.WriteLine("*********************States after 2 fight");
            Console.WriteLine();
            showInfo(actor1);
            Console.WriteLine();
            showInfo(actor2);

            actor2.ReturnState(history.GameHistory.Pop());
            actor1.ReturnState(history.GameHistory.Pop());


            Console.WriteLine();
            Console.WriteLine("*********************Return states the same after 1 fight");
            Console.WriteLine();
            showInfo(actor1);
            Console.WriteLine();
            showInfo(actor2);

        }


        static void showInfo(Actor actor)
        {
            Memento memento = actor.Save();
            Console.WriteLine($"x: {memento.PositionX}");
            Console.WriteLine($"y: {memento.PositionY}");
            Console.WriteLine($"health: {memento.Health}");
            Console.WriteLine($"weapon: {memento.Weapon.Name}, {memento.Weapon.HealthDownPosition}, {memento.Weapon.Source}");
        }
    }
}
