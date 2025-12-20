import { useParams } from 'react-router-dom'

export default function ProductDetails() {
    const { id } = useParams<{ id: string }>()
    return (
        <h2>Product Details: - {id} </h2>
    )
}
