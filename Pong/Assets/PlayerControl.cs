using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    // Tombol untuk menggerakkan ke atas
    public KeyCode upButton = KeyCode.W;

    // Tombol untuk menggerakkan ke bawah
    public KeyCode downButton = KeyCode.S;

    // Kecepatan gerak
    public float speed = 10.0f;

    // Batas atas dan bawah game scene (Batas bawah menggunakan minus (-))
    public float yBoundary = 9.0f;

    // Rigidbody 2D raket ini
    private Rigidbody2D rigidBody2D;

    // Skor pemain
    private int score;

    // Titik tumbukan terakhir dengan bola, untuk menampilkan variabel-variabel fisika terkait tumbukan tersebut
    private ContactPoint2D lastContactPoint;

    // Untuk mengakses informasi titik kontak dari kelas lain
    public ContactPoint2D LastContactPoint
    {
        get { return lastContactPoint; }
    }

    private void Awake()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        ResetScore();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        LimitMovement();
    }

    // Menaikkan skor sebanyak 1 poin
    public void IncrementScore()
    {
        score++;
    }

    // Mengembalikan skor menjadi 0
    public void ResetScore()
    {
        score = 0;
    }

    // Mendapatkan nilai skor
    public int Score
    {
        get { return score; }
    }

    void Move ()
    {
        
        // Dapatkan kecepatan raket sekarang.
        Vector2 velocity = rigidBody2D.velocity;

        // Jika pemain menekan tombol ke atas, beri kecepatan positif ke komponen y (ke atas).
        if (Input.GetKey(upButton))
        {
            velocity.y = speed;
        }

        // Jika pemain menekan tombol ke bawah, beri kecepatan negatif ke komponen y (ke bawah).
        else if (Input.GetKey(downButton))
        {
            velocity.y = -speed;
        }

        // Jika pemain tidak menekan tombol apa-apa, kecepatannya nol.
        else
        {
            velocity.y = 0.0f;
        }

        // Masukkan kembali kecepatannya ke rigidBody2D.
        rigidBody2D.velocity = velocity;


    }

    void LimitMovement ()
    {
        // Dapatkan posisi raket sekarang.
        Vector3 position = transform.position;

        // Jika posisi raket melewati batas atas (yBoundary), kembalikan ke batas atas tersebut.
        if (position.y > yBoundary)
        {
            position.y = yBoundary;
        }

        // Jika posisi raket melewati batas bawah (-yBoundary), kembalikan ke batas atas tersebut.
        else if (position.y < -yBoundary)
        {
            position.y = -yBoundary;
        }

        // Masukkan kembali posisinya ke transform.
        transform.position = position;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.Equals("Ball"))
        {
            lastContactPoint = collision.GetContact(0);
        }
    }
}
