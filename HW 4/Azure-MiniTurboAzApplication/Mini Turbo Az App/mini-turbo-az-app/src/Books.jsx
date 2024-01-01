import { useEffect } from "react"
import { useDispatch, useSelector } from "react-redux"
import { getProducts } from "./store/reducer"
import { useNavigate } from 'react-router-dom'
import "./Books.css";

export default function Books() {
    const books = useSelector((state) => state.products.books)
    const dispatch = useDispatch()
    const navigate = useNavigate()


    useEffect(() => {
        dispatch(getProducts())
    }, [dispatch])

    const handleOpenBookPage = (e, id) => {
        e.preventDefault()
        navigate(`/Book/${id}`)
    }

    return (
        <div className="books-container">
            {books && Array.isArray(books) && books.map((book) => (
                <div key={book.id}>
                    <img onClick={(e) => handleOpenBookPage(e, book.id)} src={book.images[0].url} alt={book.name} />
                    <h2>{book.name}</h2>
                    <p>Price: ${book.price}</p>
                    <p>Year: {book.year}</p>
                </div>
            ))}
        </div>
    );

}
