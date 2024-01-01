import { useEffect } from 'react';
import { useParams } from 'react-router-dom';
import { useDispatch, useSelector } from 'react-redux'
import { clear, getProductById } from './store/reducer';
import "./Book.css";
export default function Book() {
    let { id } = useParams();

    console.log(id);
    let dispatch = useDispatch()
    let book = useSelector((state) => state.products.book)

    useEffect(() => {
        dispatch(clear())
    }, [])

    useEffect(() => {
        if (id) {
            dispatch(getProductById(id))
        }
    }, [dispatch, id])


    console.log(book);
    return (
        <div className="book-container">
            {typeof book === 'object' && Object.keys(book).length > 0 ? (
                <div>
                    <h2>{book.name}</h2>
                    {book.images && book.images.length > 0 && (
                        <img src={book.images[0].url} alt={book.name} />
                    )}
                    <p>{book.description}</p>
                    <p>Price: ${book.price}</p>
                    <p>Year: {book.year}</p>
                </div>
            ) : (
                <></>
            )}
        </div>
    )
}
