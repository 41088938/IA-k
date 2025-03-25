using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookControler : MonoBehaviour
{
    
    
    [SerializeField]Animator book_animator;
    [SerializeField] Rotate3DObject1 r3d_controler;
    

    private GameObject calledBook;
    private bool isOpen = false;
    

    private void Start()
    {
       
        
    }
     
    public void ActiveBook()
    {

        book_animator.Play("Book_In_Animation");
        r3d_controler.enabled = false;


    }
   public void OffBook()
    {
        book_animator.Play("Book_Out_Animation");
        r3d_controler.enabled=true;



    }
    


}
