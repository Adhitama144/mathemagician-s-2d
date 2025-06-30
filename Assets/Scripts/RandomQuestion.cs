using UnityEngine;

public class RandomQuestion : MonoBehaviour
{
    private string[] questions = new string[]
    {
        // Operasi hitung sederhana
        "7 + 8",
        "15 - 6",
        "9 X 5",
        "45 ÷ 9",

        // Campuran operator
        "8 + 5 - 3",
        "4 X 3 + 5",
        "12 - 4 + 7",
        "10 + 4 X 2",

        // Luas bangun datar
        // "Luas persegi sisi 6 cm",
        // "Luas persegi sisi 12 cm",
        // "Luas persegi panjang P 8 cm L 5 cm",
        // "Luas persegi panjang P 15 cm L 10 cm",
        // "Luas segitiga A 10 cm T 8 cm",
        // "Luas segitiga A 12 cm T 14 cm",
        // "Luas lingkaran r 7 cm",
        // "Luas lingkaran r 14 cm",

        // Keliling bangun datar
        // "Keliling persegi sisi 6 cm",
        // "Keliling persegi sisi 12 cm",
        // "Keliling persegi panjang P 8 cm L 5 cm",
        // "Keliling persegi panjang P 15 cm L 10 cm",
        // "Keliling segitiga S1 6 cm S2 6 cm S3 6 cm",
        // "Keliling segitiga S1 10 cm S2 12 cm S3 14 cm",
        // "Keliling lingkaran r 7 cm",
        // "Keliling lingkaran r 14 cm",

        // Volume bangun ruang
        // "Volume kubus sisi 5 cm",
        // "Volume kubus sisi 12 cm",
        // "Volume balok P 4 cm L 3 cm T 2 cm",
        // "Volume balok P 10 cm L 8 cm T 6 cm",
        // "Volume tabung r 7 cm T 10 cm",
        // "Volume tabung r 14 cm T 20 cm",

        // Luas permukaan bangun ruang
        // "Luas permukaan kubus sisi 5 cm",
        // "Luas permukaan kubus sisi 12 cm",
        // "Luas permukaan balok P 4 cm L 3 cm T 2 cm",
        // "Luas permukaan balok P 10 cm L 8 cm T 6 cm",
        // "Luas permukaan tabung r 7 cm T 10 cm",
        // "Luas permukaan tabung r 14 cm T 20 cm"
    };

    private string[] answers = new string[]
    {
        // Operasi hitung
        "15", "9", "45", "5",
        "10", "17", "15", "18",

        // Luas bangun datar (jawaban tanpa kuadrat)
        //"36 cm", "144 cm", "40 cm", "150 cm", "40 cm", "84 cm", "154 cm", "616 cm",

        // Keliling bangun datar
        //"24 cm", "48 cm", "26 cm", "50 cm", "18 cm", "36 cm", "44 cm", "88 cm",

        // Volume bangun ruang
        //"125 cm", "1728 cm", "24 cm", "480 cm", "1540 cm", "6160 cm",

        // Luas permukaan bangun ruang
        //"150 cm", "864 cm", "52 cm", "376 cm", "748 cm", "1452 cm"
    };

    private System.Random rand = new System.Random();

    public (string question, string answer) GetRandomQuestionAndAnswer()
    {
        int index = rand.Next(questions.Length);
        return (questions[index], answers[index]);
    }
}