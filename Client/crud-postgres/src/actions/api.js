import axios from "axios";

const baseUrl = "https://localhost:44364/api/"

export default {

    patient(url = baseUrl + 'patient/') {
        return {
            fetchAll: () => axios.get(url),
            fetchById: id => axios.get(url + id),
            create: newRecord => axios.post(url, newRecord),
            update: (id, updateRecord) => axios.put(url + id, updateRecord),
            delete: id => axios.delete(url + id)
        }
    }
}