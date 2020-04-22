using System;
using System.Text;

namespace LibLab3
{
    public class Actor
    {
        private int _positionX;
        private int _positionY;
        private float _health;
        private WeaponUnion _weapon;

        public Actor(int x, int y, WeaponUnion w, float h = 100)
        {
            _positionX = x;
            _positionY = y;
            _weapon = w;
            if(h>0 && h <= 100)
            {
                _health = h;
            }
            else
            {
                throw new Exception("Health must to be more then 0 and less then 100");
            }

        }
      

        public void goRight(int steps)
        {
            _positionX += steps;
        }

        public void goLeft(int steps)
        {
            _positionX -= steps;
        }

        public void goUp(int steps)
        {
            _positionY += steps;
        }

        public void goDown(int steps)
        {
            _positionY -= steps;
        }


        public void changeWeapon(WeaponUnion newWeapon, Weapon weaponsLst)
        {
            if (weaponsLst.weaponsList.Contains(newWeapon))
            {
                _weapon = newWeapon;
            }
            else
            {
                throw new Exception($"{newWeapon} isn't find in weapons list");
            }
        }

        private float wound(float healthPosition)
        {
            return _health -= healthPosition;
        }

        public void fight(Actor opponent, AllActors actors)
        {
            if (_health<=0)
            {
                throw new Exception("You don't have any health and you can't do anything");
            }
            if (_weapon.Source > 0 && actors.actorsLst.Contains(opponent))
            {
                float opponentHealth = opponent.wound(_weapon.HealthDownPosition);
                if(opponentHealth <= 0)
                {
                    actors.actorsLst.Remove(opponent);
                }
                _weapon.Source--;
            }
            else
            {
                throw new Exception("The source of your weapon has already used or you opponent isn't exist");
            }

        }

        public Memento Save()
        {
            return new Memento(_positionX, _positionY, _health, _weapon);
        }

        public void ReturnState(Memento memento)
        {
            _positionX = memento.PositionX;
            _positionY = memento.PositionY;
            _health = memento.Health;
            _weapon = memento.Weapon;
        }

    }
}
