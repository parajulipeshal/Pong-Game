using System.Drawing;
namespace Logic;

public class Paddle: Rectangle, IPaddle
{
     public  float Speed {get;}
    public int MoveDirection {get;set;}
    public Paddle(bool isRight, float speed)
 {
     Height = 12;
     Width = 1.5f;
     CenterY = 50;
     CenterX = isRight
         ? 93
         : 7;

     Speed = speed; //Note(1)
 }   
}